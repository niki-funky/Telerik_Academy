using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ASP.NET_Controls
{
    public partial class studentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var univestityDict = new Dictionary<int, string>();
                univestityDict.Add(1, "NBU");
                univestityDict.Add(2, "UASG");

                ddlUniversity.DataSource = univestityDict;
                ddlUniversity.DataValueField = "key";
                ddlUniversity.DataTextField = "value";
                ddlUniversity.DataBind();

                var specialtyDict = new Dictionary<int, string>();
                specialtyDict.Add(1, "informatics");
                specialtyDict.Add(2, "architecture");

                ddlSpecialty.DataSource = specialtyDict;
                ddlSpecialty.DataValueField = "key";
                ddlSpecialty.DataTextField = "value";
                ddlSpecialty.DataBind();

                var coursesDict = new Dictionary<int, string>();
                coursesDict.Add(1, "C#");
                coursesDict.Add(2, "javascript");

                lbCourse.DataSource = coursesDict;
                lbCourse.DataValueField = "key";
                lbCourse.DataTextField = "value";
                lbCourse.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListItem item in lbCourse.Items)
            {
                if (item.Selected)
                {
                    sb.Append(item.Text + "<br>");
                }
            }
            Response.Write("<h1>Student: " + txtFirstName.Text + " " + txtLastName.Text +
                            ", facility#: " + txtFacilityNumber.Text + "</h1>" +
                            "<p> University: " + ddlUniversity.SelectedItem.Text + "<br/>" +
                             "<p> Specialty: " + ddlSpecialty.SelectedItem.Text + "<br/>" +
                             sb.ToString() + " </p>");
        }
    }
}