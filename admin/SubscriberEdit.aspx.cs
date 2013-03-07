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

public partial class admin_SubscriberEdit : System.Web.UI.Page
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

        if (Request.QueryString["SubscriberId"] != null)
        {
            int SubscriberId = Convert.ToInt32(Request.QueryString["SubscriberId"]);
            dtSubscribers  = taSubscribers.SelectSubscriberbySubscriberId(SubscriberId);
            if (dtSubscribers.Rows.Count > 0)
            {
                ddlGroup.Items.FindByValue(dtSubscribers[0].GroupId.ToString()).Selected = true;
                txtEmail.Text = dtSubscribers[0].Email.ToString();
                txtName.Text = dtSubscribers[0].Name.ToString();
                txtAddress.Text = dtSubscribers[0].Address.ToString();
                txtCity.Text = dtSubscribers[0].City.ToString();
            }
            else
            {
                lblMsg.Text = "No record found";
                btnEdit.Visible = false;
                return;
            }
        }
        else
        {
            lblMsg.Text = "No record found";
            btnEdit.Visible = false;
            return;
        }
    }

    protected void LoadGroups()
    {
        dtGroups = taGroups.SelectAllGroups();
        ddlGroup.DataSource = dtGroups;
        ddlGroup.DataTextField = dtGroups.Columns[1].ToString();
        ddlGroup.DataValueField = dtGroups.Columns[0].ToString();
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, new ListItem("Please select one", ""));
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        taSubscribers.EditSubscriber(Convert.ToInt32(Request.QueryString["SubscriberId"]),
                                     Convert.ToInt32(ddlGroup.SelectedItem.Value),
                                     txtEmail.Text.Trim(),
                                     txtName.Text.Trim(),
                                     txtAddress.Text.Trim(),
                                     txtCity.Text.Trim());

        Response.Redirect("Subscribers.aspx?SubscriberId=" + Request.QueryString["SubscriberId"] + "&ID=True");
    }
}
