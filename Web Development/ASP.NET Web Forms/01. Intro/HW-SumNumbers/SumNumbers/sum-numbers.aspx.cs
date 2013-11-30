using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumNumbers
{
    public partial class sum_numbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal firstNum = Decimal.Parse(this.TextBoxNum1.Text);
                decimal secondNum = Decimal.Parse(this.TextBoxNum2.Text);
                decimal sum = firstNum + secondNum;
                this.TextBoxSum.Text = sum.ToString();
            }
            catch (Exception)
            {
                this.TextBoxSum.Text = "Wrong sum value(s).";
            }
        }

        protected void TextBoxSum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}