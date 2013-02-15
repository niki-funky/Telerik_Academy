using System;
using System.IO;

class ReplaceSubstring
{
    // Write a program that replaces all occurrences 
    // of the substring "start" with the substring 
    // "finish" in a text file. Ensure it will work
    // with large files (e.g. 100 MB).

    static void Main()
    {
        string start = "start";
        string finish = "finish";
        string path = "../../start.txt";
        string backupPath = "../../startBackup.txt";

        ReplaceSubstringInText(path, start, finish, backupPath);
    }

    public static void ReplaceSubstringInText(string path, string search, string replace, string backupPath)
    {
        using (StreamReader sr = new StreamReader(path))
        using (StreamWriter sw = new StreamWriter("../" + path))
        {
            char[] ch = new char[search.Length];

            while (sr.Peek() != -1)
            {
                //check if array equals hunting string
                if (new string(ch) == search)
                {
                    sw.Write(replace);
                    for (int i = 0; i < ch.Length; i++)
                    {
                        ch[i] = (char)0;
                    }
                }
                else
                {
                    if (ch[0] != (char)0)
                    {
                        sw.Write(ch[0]);
                    }
                    //shift left char array
                    for (int i = 0; i < ch.Length; i++)
                    {
                        if (i < ch.Length - 1)
                        {
                            ch[i] = ch[i + 1];
                        }
                        else
                        {
                            //read chars while they are \n or \r
                            while (((char)sr.Peek() == (char)10 || (char)sr.Peek() == (char)13) && false)
                            {
                                sr.Read();
                            }
                            ch[i] = (char)sr.Read();
                        }
                    }
                }
            }
            //check if last word is our hunting string
            if (new string(ch) == search)
            {
                sw.Write(replace);
            }
            else
            {
                for (int i = 0; i < ch.Length; i++)
                {
                    if (ch[i] != (char)0)
                    {
                        sw.Write(ch[i]);
                    }
                }
            }
        }
        //create new file,delete temp and create backup of original
        FileInfo fi = new FileInfo("../" + path);
        fi.Replace(path, backupPath);
    }
}