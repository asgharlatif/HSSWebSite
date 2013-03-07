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

public partial class admin_NewsLetterGroups : System.Web.UI.Page
{
    dsNewsLetterGroupsTableAdapters.GroupsTableAdapter taGroups = new dsNewsLetterGroupsTableAdapters.GroupsTableAdapter();
    dsNewsLetterGroups.GroupsDataTable dtGroups;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Edited";
            }
        }

        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int GroupId = Convert.ToInt32(e.CommandArgument);
            taGroups.DeleteGroups(GroupId);
            BindData();
        }
        if (e.CommandName == "Edit")
        {
            int GroupId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("NewsLetterGroupEdit.aspx?GroupId=" + GroupId);
        }
        if (e.CommandName == "Subscribers")
        {
            int GroupId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Subscribers.aspx?GroupId=" + GroupId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDel = (LinkButton)e.Row.FindControl("lbtnDelete");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");
        }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    private void BindData()
    {
        dtGroups = taGroups.SelectAllGroups();

        if (dtGroups.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtGroups;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }
}
