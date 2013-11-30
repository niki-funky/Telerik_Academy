
namespace FolderStructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Folder
    {
        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public Folder(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(
                    "Folder must have name!");
            }

            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }
    }
}