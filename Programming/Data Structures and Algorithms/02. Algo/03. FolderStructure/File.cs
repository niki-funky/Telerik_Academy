
namespace FolderStructure
{
    using System;
    using System.Linq;

    public class File
    {
        public string Name { get; set; }

        public long Size { get; set; }

        public File(string name, long size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(
                    "File must have name!");
            }

            this.Name = name;
            this.Size = size;
        }
    }
}