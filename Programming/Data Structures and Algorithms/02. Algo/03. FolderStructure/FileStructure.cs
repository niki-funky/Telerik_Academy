
namespace FolderStructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class FileStructure
    {
        static void Main(string[] args)
        {
            string folder = @"C:\Windows";
            Folder root = new Folder(folder);
            DirectoryInfo di = new DirectoryInfo(root.Name);

            FindAllFoldersAndFiles(di, root);

            // find sum of all files in a subtree 
            long sum;
            string subFolder = "Inf";
            Folder subTree = root.ChildFolders.Find(x => x.Name == subFolder);

            sum = FindSizeOfSubTree(subTree);

            Console.WriteLine("Sum of all files in the subtree {0} is {1}: " 
                + " bytes", subFolder, sum);
        }

        private static void FindAllFoldersAndFiles(DirectoryInfo di, Folder root)
        {
            try
            {
                var files = di.EnumerateFiles();
                foreach (var file in files)
                {
                    var currentFile = new File(file.Name, file.Length);
                    root.Files.Add(currentFile);
                }

                var folders = di.EnumerateDirectories();
                foreach (var folder in folders)
                {
                    var currentFolder = new Folder(folder.Name);
                    root.ChildFolders.Add(currentFolder);

                    FindAllFoldersAndFiles(folder, currentFolder);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static long FindSizeOfSubTree(Folder folder)
        {
            long sum = 0;
            Stack<Folder> stack = new Stack<Folder>();
            stack.Push(folder);

            while (stack.Count > 0)
            {
                Folder currentFolder = stack.Pop();
                foreach (var subFolder in currentFolder.ChildFolders)
                {
                    stack.Push(subFolder);
                    foreach (var file in subFolder.Files)
                    {
                        sum += file.Size;
                    }

                    FindSizeOfSubTree(subFolder);
                }
            }

            return sum;
        }
    }
}
