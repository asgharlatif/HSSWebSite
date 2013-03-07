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

public partial class admin_Customers : System.Web.UI.Page
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
        dtCustomers = taCustomers.SelectAllCustomers();
        if (dtCustomers.Rows.Count > 0)
        {
            GridView1.DataSource = dtCustomers;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "No record found";
        }
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int customerId = Convert.ToInt32(e.CommandArgument);
            taCustomers.DeleteCustomer(customerId);
            BindData();
        }

        if (e.CommandName == "View")
        {
            int customerId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("CustomerDetail.aspx?CustomerId=" + customerId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDel = (LinkButton)e.Row.FindControl("delbutton");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}
