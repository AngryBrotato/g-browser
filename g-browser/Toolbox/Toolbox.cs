using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Toolbox
{
    public class Helpers
    {
    }
    public class DataExporter
    {
        public void export(List<FileData> files)
        {
            var json = JsonConvert.SerializeObject(files);
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folderPath = Path.Combine(appDataPath, "gbrowser");
            var fileName = Path.Combine(folderPath, "gdata.json");
            var backupFileName = fileName + ".bak";

            Directory.CreateDirectory(folderPath);
            saveFile(fileName, backupFileName, json);
        }
        private void saveFile(string fileName, string backupFileName, string json)
        {

            if (File.Exists(backupFileName)) File.Delete(backupFileName);
            if (File.Exists(fileName)) File.Move(fileName, backupFileName);

            File.WriteAllText(fileName, json);
        }
    }

    public class FileScanner
    {
        public List<FileData> SelectFiles(string rootFolder, string extension = "*")
        {
            DirectoryInfo dirInfo = new DirectoryInfo(rootFolder);
            var files = new List<FileData>();

            // Look at all of the files in the current folder
            dirInfo.GetFiles("*." + extension)
                .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                .Where(f => !f.Name.StartsWith("."))
                .ToList()
                .ForEach(
                    f =>
                    {
                        var details = FileVersionInfo.GetVersionInfo(f.FullName);
                        if (details.FileDescription == "") return;
                        FileData temp_file = new FileData();
                        temp_file.CreationDate = f.CreationTime;
                        temp_file.LastUsed = f.LastAccessTime;
                        temp_file.Details = details;
                        temp_file.FileName = f.Name.Split('.')[0];
                        temp_file.Size = Convert.ToUInt32(f.Length);
                        temp_file.ParentDir = f.DirectoryName;
                        temp_file.FileNameFull = f.FullName;
                        temp_file.Extension = f.Extension;
                        temp_file.SuggestedNames = ReadInfo(temp_file);

                        if (temp_file.SuggestedNames.Count > 0)
                            files.Add(temp_file);
                    });

            // Look into each sub-directory and call this function again on each of them.
            dirInfo.GetDirectories()
                .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                // Ignore folder names:
                .Where(f => !f.Name.StartsWith(".") 
                         && !f.Name.StartsWith("node_modules")
                         && !f.Name.StartsWith("git"))
                .ToList()
                .ForEach(
                    d => SelectFiles(d.FullName, extension).ForEach(files.Add)
                );
            return files;
        }

        public List<NameSuggestion> ReadInfo(FileData file)
        {
            List<NameSuggestion> suggestions = new List<NameSuggestion>();
            List<string> directories = file.ParentDir.Split('\\').ToList();
            string filename = file.FileName;

            var numOfTimesToLoop = filename.Length/3;
            for (int i = 0; i < numOfTimesToLoop; i++)
            {
                var mod = 0;
                directories.ForEach(
                    d =>
                    {
                        var substring = filename.Substring(i + mod, i + numOfTimesToLoop);
                        if (d.Contains(substring))
                            suggestions.Add(new NameSuggestion(d, substring));
                    }
                );
                mod += 3;
            }
            return suggestions;
        }
    }

    public class NameSuggestion
    {
        public string Value { get; set; }
        public int Length { get; }
        public string MatchedBit { get; }

        public NameSuggestion(string value, string matchedBit = "")
        {
            this.Value = value;
            this.Length = value.Length;
            this.MatchedBit = matchedBit;
        }
    }

    public class FileData
    {
        public string FileName { get; set; }
        public string FileNameFull { get; set; }
        public string Extension { get; set; }
        public string ParentDir { get; set; }
        public GameData GameInfo { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUsed { get; set; }
        public FileType Type { get; set; }
        public FileVersionInfo Details { get; set; }
        public List<NameSuggestion> SuggestedNames { get; set; }
    }

    public enum FileType
    {
        Launcher, Game, Installer, Resource, Unknown
    }

    public class GameData
    {
        public string Title;
        public string Description;
        public string Rating;
        public string[] Tags;

        public GameData(string title, string description, string rating = "n/a", string[] tags = null)
        {
            this.Title = title;
            this.Description = description;
            this.Rating = rating;
            this.Tags = tags;
        }
    }
}
