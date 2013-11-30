using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Continents
{
    public partial class Continents : System.Web.UI.Page
    {
        //public void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    //set current page startindex, max rows and rebind to false
        //    lvDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

        //    //rebind List View
        //    lvDataPager.DataBind();
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {
            this.lvTowns.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewTowns_ItemInserted(object sender,
            ListViewInsertedEventArgs e)
        {
            this.lvTowns.InsertItemPosition = InsertItemPosition.None;
        }

        protected void grdCountries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ContinentDBEntities db = new ContinentDBEntities();
            using (db)
            {

                var countryId = int.Parse(grdCountries.DataKeys[e.RowIndex].Value.ToString());
                var towns = from t in db.Towns
                            where t.Country_Id == countryId
                            select t;

                db.Towns.RemoveRange(towns);
                db.SaveChanges();
            }
        }

        protected void grdCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        //protected void upload_Click(object sender, EventArgs e)
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = grdCountries.Rows[index];

            if (e.CommandName.ToLower() != "upload")
            {
                return;
            }

            //get index of clicked Item
            Button btn = (Button)e.CommandSource;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            var itemIndex = int.Parse(grdCountries.DataKeys[gvRow.RowIndex].Value.ToString());


            Button bts = e.CommandSource as Button;
            Response.Write(bts.Parent.Parent.GetType().ToString());

            FileUpload fu = bts.FindControl("FileUpload") as FileUpload;//here 

            if (fu.HasFile)
            {
                bool upload = true;
                string fleUpload = Path.GetExtension(fu.FileName.ToString());
                if (fleUpload.Trim().ToLower() == ".png")
                {
                    ContinentDBEntities db = new ContinentDBEntities();
                    using (db)
                    {
                        //fu.SaveAs(Server.MapPath("~/UpLoadPath/" + fu.FileName.ToString()));
                        //string uploadedFile = (Server.MapPath("~/UpLoadPath/" + fu.FileName.ToString()));

                        byte[] buffer = new byte[fu.FileContent.Length];
                        Stream s = fu.FileContent;
                        s.Read(buffer, 0, buffer.Length);


                        var currCountry = db.Countries.Where(c => c.Id == itemIndex).FirstOrDefault();
                        currCountry.Flag = buffer;

                        db.SaveChanges();

                        //Someting to do?...
                    }
                }
                else
                {
                    upload = false;
                    // Something to do?...
                }
                if (upload)
                {
                    // somthing to do?...
                }
            }
            else
            {
                //Something to do?...
            }
        }

        //protected void upload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string filename = Path.GetFileName(fileupload.PostedFile.FileName);
        //        fileupload.SaveAs(Server.MapPath("~/Images/" + filename));
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageSql"].ConnectionString);
        //        con.Open();
        //        cmd = new SqlCommand("insert into Image_Details (ImageName,Image) values(@ImageName,@Image)", con);
        //        cmd.Parameters.AddWithValue("@ImageName", filename);
        //        cmd.Parameters.AddWithValue("@Image", "Images/" + filename);
        //        cmd.ExecuteNonQuery();
        //        da = new SqlDataAdapter("select * from Image_Details", con);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        gdImage.DataSource = ds;
        //        gdImage.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        upload.Text = ex.Message;
        //    }
        //}
    }
}