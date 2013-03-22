using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public class DocumentSystemConsole
    {
        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        public static IList<Documents> documents = new List<Documents>();

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            Utilities.AddDocuments(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            Utilities.AddDocuments(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            Utilities.AddDocuments(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            Utilities.AddDocuments(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            Utilities.AddDocuments(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            Utilities.AddDocuments(new VideoDocument(), attributes);
        }

        private static void ListDocuments()
        {
            var counter = 0;
            foreach (var item in documents)
            {
                Console.WriteLine(item);
                counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("No documents found");
            }
        }

        private static void EncryptDocument(string name)
        {
            bool exists = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    if (item is IEncryptable)
                    {
                        (item as Encrypted).Encrypt();
                        Console.WriteLine("Document encrypted: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: " + name);
                    }
                    exists = true;
                }
            }
            if (!exists)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool exists = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    if (item is IEncryptable)
                    {
                        (item as Encrypted).Decrypt();
                        Console.WriteLine("Document decrypted: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: " + name);
                    }
                    exists = true;
                }
            }
            if (!exists)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void EncryptAllDocuments()
        {
            var counter = 0;
            foreach (var item in documents)
            {
                if (item is IEncryptable)
                {
                    (item as Encrypted).Encrypt();
                    counter++;
                }
            }
            if (counter > 0)
            {
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool exists = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    if (item is IEditable)
                    {
                        (item as IEditable).ChangeContent(content);
                        Console.WriteLine("Document content changed: " + name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: " + name);
                    }
                    exists = true;
                }
            }
            if (!exists)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

    }
}
