using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Toolbox;

namespace Scanner
{
    public class Scanner
    {
        public List<FileData> selectfolders(string filename, string extension = "*")
        {
            DirectoryInfo dirInfo = new DirectoryInfo(filename);
            var files = new List<FileData>();

            dirInfo.GetFiles("*." + extension)
                .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                .Where(f => !f.Name.StartsWith("."))
                .ToList()
                .ForEach(
                    f =>
                     {
                         FileData temp_file = new FileData();
                         temp_file.FileName = f.Name;
                         temp_file.Size = Convert.ToUInt32(f.Length);
                         temp_file.ParentDir = f.DirectoryName;
                         temp_file.FileName_full = f.FullName;
                         temp_file.Extension = f.Extension;
                         files.Add(temp_file);
                     });

            dirInfo.GetDirectories()
                .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                .Where(f => !f.Name.StartsWith(".") && !f.Name.StartsWith("node_modules"))
                .ToList()
                .ForEach(
                    d => selectfolders(d.FullName, extension).ForEach(files.Add)
                );
            return files;
        }
    }
}
