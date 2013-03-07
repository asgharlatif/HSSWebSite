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

public partial class admin_NewsLetterGroupEdit : System.Web.UI.Page
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

        if (Request.QueryString["GroupId"] != null)
        {
            int GroupId = Convert.ToInt32(Request.QueryString["GroupId"]);
            dtGroups = taGroups.SelectGroupbyGroupId(GroupId);
            if (dtGroups.Rows.Count > 0)
            {
                txtTitle.Text = dtGroups[0].GroupName.ToString();
            }
            else
            {
                lblMsg.Text = "No record found";
                return;
            }
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        taGroups.EditGroup(Convert.ToInt32(Request.QueryString["GroupId"]),
                           txtTitle.Text.Trim());

        Response.Redirect("NewsLetterGroups.aspx?GroupId=" + Request.QueryString["GroupId"] + "&ID=True");
    }
}
