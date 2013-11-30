using System;
using System.Linq;
using System.IO;
using System.Net;
using Cloudinary;

namespace OfferWorld.WebApi.Helpers
{
    public class Cloudinary
    {
        public void downloadFile()
        {
            try
            {
                //create WebClient object
                WebClient client = new WebClient();
                string myFile = @"C:\file.txt";
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UploadFile(@"http://myweb.com/projects/idl/Draft Results/RK/myFile", "PUT", myFile);
                client.Dispose();
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
            }
        }

        private void uploadToCloud(string filename, Stream fileStream)
        {
            if (filename.EndsWith("png") || filename.EndsWith("jpeg") || 
                filename.EndsWith("jpg") || filename.EndsWith("gif") || filename.EndsWith("bmp"))
            {
                try
                {
                    var configuration = new AccountConfiguration("hscl3sr21", "773858917884263", "RWVBnZhCDPyOrKAYihbubppmZ4E");

                    var uploader = new Uploader(configuration);
                    string publicId = Path.GetFileNameWithoutExtension(filename);
                    var uploadResult = uploader.Upload(new UploadInformation(filename, fileStream)
                    {
                        PublicId = publicId,
                        Format = filename.Substring(filename.Length - 3),
                    });
                }
                catch (Exception ex)
                {
                    //context.Response.Write("{ 'success': " + ex.Message + " }");
                    return;
                }
            }
        }
    }
}