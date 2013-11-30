using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.AssemblyLocation
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fromCsharp.Text = "Hello, ASP.NET - from C# code behind<br />" + 
                Assembly.GetExecutingAssembly().Location;

        }
    }
}