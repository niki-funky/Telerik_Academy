using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Controls
{
    public partial class escapingHtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                txtRead.Text = Server.HtmlEncode(txtSend.Text);
                lblRead.Text = Server.HtmlEncode(txtSend.Text);
            }
        }
    }
}