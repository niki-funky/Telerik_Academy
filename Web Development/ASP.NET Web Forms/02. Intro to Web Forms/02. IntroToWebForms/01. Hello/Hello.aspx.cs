using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.Hello
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonResult_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.TextBoxName.Text;
                this.TextBoxResult.Text = "Hello " + name.ToString();
            }
            catch (Exception)
            {
                this.TextBoxResult.Text = "Invalid.";
            }
        }
    }
}