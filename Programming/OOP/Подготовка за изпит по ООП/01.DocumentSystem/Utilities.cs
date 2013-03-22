using System;
using System.Linq;

namespace DocumentSystem
{
    class Utilities
    {
        //methods
        public static void AddDocuments(Documents doc, string[] attributes)
        {
            foreach (var item in attributes)
            {
                string[] keyValuePair = item.Split(
                new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                doc.LoadProperty(keyValuePair[0], keyValuePair[1]);
            }
            if (doc.Name != null)
            {
                DocumentSystemConsole.documents.Add(doc);
                Console.WriteLine("Document added: " + doc.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        public static bool isEncrypted(IDocument doc)
        {
            bool isEncrypted = false;
            //if (DocumentSystemConsole.documents.Any(x => x is IEncryptable && (x as IEncryptable).IsEncrypted))
            if (doc  is IEncryptable && (doc as IEncryptable).IsEncrypted)
            {
                isEncrypted = true;
            }
            return isEncrypted;
        }

        //public static bool documentExists(string name)
        //{
        //    bool exists = false;
        //    if (DocumentSystemConsole.documents.Any(x => x.Name == name))
        //    {
        //        exists = true;
        //    }
        //    return exists;
        //}

        //public static bool isEditable(string name)
        //{
        //    bool isEditable = false;
        //    if (DocumentSystemConsole.documents.Any(x =>x.Name == name && x is IEditable))
        //    {
        //        isEditable = true;
        //    }
        //    return isEditable;
        //}
    }
}
