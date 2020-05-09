using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace BananaSplit
{
    public class MKVToolNix
    {
        private Process Process { get; set; }

        public MKVToolNix()
        {
            Process = new Process();

            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardError = true;
			Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.CreateNoWindow = true;
        }

		public string RemuxToMatroska(string filepath)
		{
			var basename = Path.GetFileNameWithoutExtension(filepath);
			var path = Path.GetDirectoryName(filepath);
			var extensionlessPath = Path.Combine(path, basename);

			Process.StartInfo.FileName = "mkvmerge.exe";
			Process.StartInfo.Arguments = $"-o \"{extensionlessPath}.mkv\" \"{filepath}\"";

			Process.Start();
			Process.WaitForExit();

			return extensionlessPath + ".mkv";
		}

		public void InjectChapters(string filepath, Chapters chapters)
		{
			var temporaryXmlFile = Path.GetTempFileName();
			var temporaryOutputFile = Path.GetTempFileName();

			Process.StartInfo.FileName = "mkvmerge.exe";
			Process.StartInfo.Arguments = $"--chapters \"{temporaryXmlFile}\" -o \"{temporaryOutputFile}\" \"{filepath}\"";

			XmlSerializer serializer = new XmlSerializer(typeof(Chapters));
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add("", "");

			TextWriter writer = new StreamWriter(temporaryXmlFile);

			serializer.Serialize(writer, chapters, namespaces);

			writer.Close();

			Process.Start();

			var error = Process.StandardError.ReadToEnd();
			var output = Process.StandardOutput.ReadToEnd();

			Process.WaitForExit();

			File.Delete(filepath);
			File.Move(temporaryOutputFile, filepath);
			File.Delete(temporaryXmlFile);
		}

		public Chapters GenerateChapters(IEnumerable<TimeSpan> segments)
		{
			var chapters = new Chapters();
			var editionEntry = new EditionEntry() {
				EditionFlagHidden = 0,
				EditionFlagDefault = 0,
				EditionUID = 1,
				ChapterAtom = new List<ChapterAtom>()
			};

			int i = 1;

			foreach (var segment in segments)
			{
				var chapterAtom = new ChapterAtom();
				var timestamp = String.Format("{0:D2}:{1:D2}:{2:D2}.{3}", segment.Hours, segment.Minutes, segment.Seconds, segment.Milliseconds);

				chapterAtom.ChapterUID = i;
				chapterAtom.ChapterFlagHidden = 0;
				chapterAtom.ChapterFlagEnabled = 1;
				chapterAtom.ChapterTimeStart = timestamp;
				chapterAtom.ChapterDisplay = new ChapterDisplay()
				{
					ChapterLanguage = "eng",
					ChapterString = timestamp
				};

				editionEntry.ChapterAtom.Add(chapterAtom);

				i++;
			}

			chapters.EditionEntry = editionEntry;
			return chapters;
		}
    }

	[XmlRoot(ElementName = "ChapterDisplay")]
	public class ChapterDisplay
	{
		[XmlElement(ElementName = "ChapterString")]
		public string ChapterString { get; set; }
		[XmlElement(ElementName = "ChapterLanguage")]
		public string ChapterLanguage { get; set; }
	}

	[XmlRoot(ElementName = "ChapterAtom")]
	public class ChapterAtom
	{
		[XmlElement(ElementName = "ChapterUID")]
		public int ChapterUID { get; set; }
		[XmlElement(ElementName = "ChapterTimeStart")]
		public string ChapterTimeStart { get; set; }
		[XmlElement(ElementName = "ChapterFlagHidden")]
		public int ChapterFlagHidden { get; set; }
		[XmlElement(ElementName = "ChapterFlagEnabled")]
		public int ChapterFlagEnabled { get; set; }
		[XmlElement(ElementName = "ChapterDisplay")]
		public ChapterDisplay ChapterDisplay { get; set; }
	}

	[XmlRoot(ElementName = "EditionEntry")]
	public class EditionEntry
	{
		[XmlElement(ElementName = "EditionFlagHidden")]
		public int EditionFlagHidden { get; set; }
		[XmlElement(ElementName = "EditionFlagDefault")]
		public int EditionFlagDefault { get; set; }
		[XmlElement(ElementName = "EditionUID")]
		public int EditionUID { get; set; }
		[XmlElement(ElementName = "ChapterAtom")]
		public List<ChapterAtom> ChapterAtom { get; set; }
	}

	[XmlRoot(ElementName = "Chapters")]
	public class Chapters
	{
		[XmlElement(ElementName = "EditionEntry")]
		public EditionEntry EditionEntry { get; set; }
	}
}
