using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Text;

namespace BananaSplit
{
    public enum ProcessingType
    {
        [Display(Name = "Matroska Chapters")]
        MatroskaChapters,
        [Display(Name = "Split and Encode")]
        SplitAndEncode
    }

    public class Settings
    {
        public double BlackFrameDuration { get; set; }
        public double BlackFrameThreshold { get; set; }
        public string FFMPEGArguments { get; set; }
        public ProcessingType ProcessType { get; set; }
        public bool DeleteOriginal { get; set; }
        public double ReferenceFrameOffset { get; set; }

        public Settings()
        {
            BlackFrameDuration = 0.04;
            BlackFrameThreshold = 0.01;
            FFMPEGArguments = "";
            ProcessType = ProcessingType.MatroskaChapters;
            DeleteOriginal = false;
            ReferenceFrameOffset = 1;
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
            FFMPEGArguments = settings.FFMPEGArguments;
            ProcessType = settings.ProcessType;
            DeleteOriginal = settings.DeleteOriginal;
            ReferenceFrameOffset = settings.ReferenceFrameOffset;
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);

            File.WriteAllText("Settings.json", json);
        }
    }
}
