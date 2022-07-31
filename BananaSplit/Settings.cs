using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BananaSplit
{
    public enum ProcessingType
    {
        [Display(Name = "Matroska Chapters")]
        MatroskaChapters,
        [Display(Name = "Split and Encode")]
        SplitAndEncode,
        [Display(Name = "MKVToolNix Split")]
        MKVToolNixSplit
    }

    public enum RenameType
    {
        [Display(Name = "Prefix")]
        Prefix,
        [Display(Name = "Suffix")]
        Suffix,
        [Display(Name = "Append After")]
        AppendAfter,
        [Display(Name = "Replace")]
        Replace,
        [Display(Name = "Increment")]
        Increment
    }


    public class Settings
    {
        public double BlackFrameDuration { get; set; }
        public double BlackFrameThreshold { get; set; }
        public double BlackFramePixelThreshold { get; set; }
        public string FFMPEGArguments { get; set; }
        public ProcessingType ProcessType { get; set; }
        public bool ShowLog { get; set; }
        public bool DeleteOriginal { get; set; }
        public double ReferenceFrameOffset { get; set; }
        public string RenameFindText { get; set; }
        public string RenameNewText { get; set; }
        public RenameType RenameType { get; set; }
        public bool RenameOriginal { get; set; }

        public Settings()
        {
            BlackFrameDuration = 0.04;
            BlackFrameThreshold = 0.98;
            BlackFramePixelThreshold = 0.15;
            FFMPEGArguments = "-i \"{source}\" -ss {start} -t {duration} -c:v libx264 -crf 18 -preset slow -c:a copy -map 0 \"{destination}\"";
            ProcessType = ProcessingType.MKVToolNixSplit;
            ShowLog = false;
            DeleteOriginal = false;
            ReferenceFrameOffset = 1;
            RenameFindText = "";
            RenameNewText = "{i}";
            RenameType = RenameType.Increment;
            RenameOriginal = true;
        }

        public void Load()
        {
            Settings settings;

            if (File.Exists("Settings.json"))
            {
                var json = File.ReadAllText("Settings.json");

                try
                {
                    settings = JsonConvert.DeserializeObject<Settings>(json);
                }
                catch
                {
                    settings = new Settings();
                    settings.Save();
                }
            }
            else
            {
                settings = new Settings();
                settings.Save();
            }

            BlackFrameDuration = settings.BlackFrameDuration;
            BlackFrameThreshold = settings.BlackFrameThreshold;
            BlackFramePixelThreshold = settings.BlackFramePixelThreshold;
            FFMPEGArguments = settings.FFMPEGArguments;
            ProcessType = settings.ProcessType;
            ShowLog = settings.ShowLog;
            DeleteOriginal = settings.DeleteOriginal;
            ReferenceFrameOffset = settings.ReferenceFrameOffset;
            RenameFindText = settings.RenameFindText;
            RenameNewText = settings.RenameNewText;
            RenameType = settings.RenameType;
            RenameOriginal = settings.RenameOriginal;
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);

            File.WriteAllText("Settings.json", json);
        }
    }
}
