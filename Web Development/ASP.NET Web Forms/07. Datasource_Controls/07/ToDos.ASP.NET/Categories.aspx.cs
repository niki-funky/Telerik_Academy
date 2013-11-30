using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDos.ASP.NET
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                int categoryId = 0;
                if (!string.IsNullOrEmpty(btnSave.CommandArgument))
                {
                    categoryId = int.Parse(btnSave.CommandArgument);
                }

                var db = new ToDosDBEntities2();
                Category c = db.Categories.Find(categoryId);
                if (c == null)
                {
                    c = new Category();
                }
                c.Name = txtName.Text;
                db.Categories.Add(c);
                db.SaveChanges();
                txtName.Text = string.Empty;
                btnSave.CommandArgument = string.Empty;
                lbCategories.DataBind();
            }
        }

        protected void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = lbCategories.SelectedItem.Text;
            btnSave.CommandArgument = lbCategories.SelectedItem.Value;
        }
    }
}