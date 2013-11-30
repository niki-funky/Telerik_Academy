using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Controls
{
    public partial class generate_random_number : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_generateNumber_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstNumber.Text) && !string.IsNullOrEmpty(secondNumber.Text))
            {
                lblRangeResult.Text =
                    random.Next(int.Parse(firstNumber.Text), int.Parse(secondNumber.Text)).ToString();

            }
        }
    }
}