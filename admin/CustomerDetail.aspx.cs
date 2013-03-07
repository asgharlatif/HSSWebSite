using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_CustomerDetail : System.Web.UI.Page
{
    dsCustomersTableAdapters.CustomersTableAdapter taCustomers = new dsCustomersTableAdapters.CustomersTableAdapter();
    dsCustomers.CustomersDataTable dtCustomers;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        BindData();
    }
    private void BindData()
    {
        if (Request.QueryString["CustomerId"] != null)
        {
            int customerId = Convert.ToInt32(Request.QueryString["CustomerId"]);
            dtCustomers = taCustomers.SelectCustomerbyCustomerId(customerId);
            if (dtCustomers.Rows.Count > 0)
            {
                DetailsView1.DataSource = dtCustomers;
                DetailsView1.DataBind();
            }
            else
            {
                DetailsView1.Visible = false;
                lblMsg.Text = "No record found";
            }
        }
        else
        {
            DetailsView1.Visible = false;
            lblMsg.Text = "No record found";
        }
    }
}
