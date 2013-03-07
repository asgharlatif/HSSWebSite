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

public partial class admin_Subscribers : System.Web.UI.Page
{
    dsSubscribersTableAdapters.SubscribersTableAdapter taSubscribers = new dsSubscribersTableAdapters.SubscribersTableAdapter();
    dsSubscribers.SubscribersDataTable dtSubscribers;
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

        LoadGroups();

        BindData();
        
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int SubscriberId = Convert.ToInt32(e.CommandArgument);
            taSubscribers.DeleteSubscribers(SubscriberId);
            BindData();
        }
        if (e.CommandName == "Edit")
        {
            int SubscriberId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("SubscriberEdit.aspx?SubscriberId=" + SubscriberId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblGroupId = (Label)e.Row.FindControl("lblGroupId");
            dtGroups = taGroups.SelectGroupNamebyGroupId(Convert.ToInt32(lblGroupId.Text));
            if (dtGroups.Rows.Count > 0)
                lblGroupId.Text = dtGroups[0].GroupName.ToString();
            else
                lblGroupId.Visible = false;

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
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Subscribers.aspx?GroupId=" + ddlGroup.SelectedItem.Value);
    }
    protected void LoadGroups()
    {
        dtGroups = taGroups.SelectAllGroups();
        ddlGroup.DataSource = dtGroups;
        ddlGroup.DataTextField = dtGroups.Columns[1].ToString();
        ddlGroup.DataValueField = dtGroups.Columns[0].ToString();
        ddlGroup.DataBind();
    }
    
    private void BindData()
    {
        if (Request.QueryString["GroupId"] != null)
        {
            int GroupId = Convert.ToInt32(Request.QueryString["GroupId"]);
            dtSubscribers = taSubscribers.SelectSubscriberbyGroupId(GroupId);
            ddlGroup.Items.FindByValue(GroupId.ToString()).Selected = true;
        }
        else
            dtSubscribers = taSubscribers.SelectAllSubscribers();

        if (dtSubscribers.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtSubscribers;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }
}
