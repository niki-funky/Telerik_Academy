using System;
using System.Net;

class ReadFile
{
    // Write a program that downloads a file from Internet
    // (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and
    // stores it the current directory. Find in Google how 
    // to download files in C#. Be sure to catch all exceptions
    // and to free any used resources in the finally block.

    static void Main()
    {
        WebClient client = new WebClient();
        using (client)
        {
            try
            {
                client.DownloadFile("http://academy.telerik.com/images/default-album/telerik-academy-banner-300x250.jpg?sfvrsn=2",
                            "../../../telerik-academy-banner-300x250.jpg");
            }
            catch (WebException we)
            {
                Console.Error.WriteLine("File is inaccessible!" + we.Message);
            }

            catch (NotSupportedException ne)
            {
                Console.Error.WriteLine("Ooops something went wrong!" + ne.Message);
            }
            catch (ArgumentNullException ae)
            {
                Console.Error.WriteLine("Ooops something went wrong!" + ae.Message);
            }
        }
    }
}
