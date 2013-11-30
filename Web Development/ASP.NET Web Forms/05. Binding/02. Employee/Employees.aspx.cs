using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Employee
{
    public partial class Employees : System.Web.UI.Page
    {
        int RowCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NORTHWNDEntities db = new NORTHWNDEntities();
                GridFill(db);

                FetchData(10, 0); 

                //rEmployees.DataSource = db.Employees.ToList();
                //rEmployees.DataBind();

                lvEmployees.DataSource = db.Employees.ToList();
                lvEmployees.DataBind();
            }
            else
            {
                plcPaging.Controls.Clear();
                CreatePagingControl();
            } 
        }

        private void GridFill(NORTHWNDEntities db)
        {
            //NORTHWNDEntities db = new NORTHWNDEntities();
            grdEmployers.DataSource = db.Employees.Select(x => new
            {
                Id = x.EmployeeID,
                FullName = x.FirstName + " " + x.LastName
            }).ToList();

            grdEmployers.DataBind();
        }

        public void grdEmployers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            this.grdEmployers.PageIndex = e.NewPageIndex;
            GridFill(db);
        }

        protected void grdEmployers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eId = int.Parse(grdEmployers.SelectedDataKey.Value.ToString());
            NORTHWNDEntities db = new NORTHWNDEntities();
            grdFormView.DataSource = new List<Employee>()
                {
                    db.Employees.FirstOrDefault(x => x.EmployeeID == eId)
                };
            grdFormView.DataBind();
        }

        // paging for repeater
        private void FetchData(int take, int pageSize)
        {
            using (NORTHWNDEntities dc = new NORTHWNDEntities())
            {
                var query = from p in dc.Employees
                            .OrderBy(o => o.FirstName)
                            .Take(take)
                            .Skip(pageSize)
                            select new
                            {
                                ID = p.EmployeeID,
                                Name = p.FirstName + "" + p.LastName,
                                Count = dc.Employees.Count()
                            };

                PagedDataSource page = new PagedDataSource();
                page.AllowCustomPaging = true;
                page.AllowPaging = true;
                page.DataSource = query;
                page.PageSize = 10;

                rEmployees.DataSource = page;
                rEmployees.DataBind();

                if (!IsPostBack)
                {
                    RowCount = query.First().Count;
                    CreatePagingControl();
                }
            }
        }

        private void CreatePagingControl()
        {
            for (int i = 0; i < (RowCount / 10) + 1; i++)
            {
                LinkButton lnk = new LinkButton();
                lnk.Click += new EventHandler(lbl_Click);
                lnk.ID = "lnkPage" + (i + 1).ToString();
                lnk.Text = (i + 1).ToString();
                plcPaging.Controls.Add(lnk);
                Label spacer = new Label();
                spacer.Text = "&nbsp;";
                plcPaging.Controls.Add(spacer);
            }
        }

        void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);
            int take = currentPage * 10;
            int skip = currentPage == 1 ? 0 : take - 10;
            FetchData(take, skip);
        }
    }
}