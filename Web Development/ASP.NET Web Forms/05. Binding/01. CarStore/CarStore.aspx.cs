using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarStore
{
    public partial class CarStore : System.Web.UI.Page
    {
        List<Producer> producers;
        List<Extra> extras;
        protected void Page_Init(object sender, EventArgs e)
        {
            producers = new List<Producer>()
            {
                new Producer(){Id = 1,  Name = "BMW", Models = new List<Model>()
                {   new Model(){Id = 1, Name = "M5"},
                    new Model(){Id = 2, Name = "Cabrio"},
                    new Model(){Id = 3, Name = "Sport"}
                }},
                new Producer(){Id = 2,  Name = "Mercedes", Models = new List<Model>()
                {   new Model(){Id = 1, Name = "SL500"},
                    new Model(){Id = 2, Name = "A500"},
                    new Model(){Id = 3, Name = "S600"}
                }},
                new Producer(){Id = 3,  Name = "Opel", Models = new List<Model>()
                {   new Model(){Id = 1, Name = "Corsa"},
                    new Model(){Id = 2, Name = "Kadett"},
                    new Model(){Id = 3, Name = "Vectra"}
                }},
            };
            extras = new List<Extra>()
            {
                new Extra(){Id = 1, Name = "Top roof"},
                new Extra(){Id = 1, Name = "Nuclear engine"},
                new Extra(){Id = 1, Name = "Teleportation"},
            };
        }

        protected void ddlProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlProducers.SelectedValue.ToString());
            ddlModels.DataSource = producers.FirstOrDefault(p => p.Id == id).Models;
            ddlModels.DataValueField = "Id";
            ddlModels.DataTextField = "Name";
            ddlModels.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducers.DataSource = producers;
                ddlProducers.DataValueField = "Id";
                ddlProducers.DataTextField = "Name";
                ddlProducers.DataBind();
                ddlProducers_SelectedIndexChanged(ddlProducers, null);

                cbExtras.DataSource = extras;
                cbExtras.DataValueField = "Id";
                cbExtras.DataTextField = "Name";
                cbExtras.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Format("Producer: {0}, Model: {1}, Extras: {2}, Engine: {3}",
                ddlProducers.SelectedItem.Text,
                ddlModels.SelectedItem.Text,
                string.Join(", ", cbExtras.Items.Cast<ListItem>().Where(x => x.Selected).ToList()),
                rbEngine.SelectedItem.Text); ;
        }
    }
}