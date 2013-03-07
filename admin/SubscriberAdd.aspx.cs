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

public partial class admin_SubscriberAdd : System.Web.UI.Page
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
                lblMsg.Text = "Successfully Added";
            }
        }

        LoadGroups();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        taSubscribers.AddSubscriber(Convert.ToInt32(ddlGroup.SelectedItem.Value),
                                    txtEmail.Text.Trim(),
                                    txtName.Text.Trim(),
                                    txtAddress.Text.Trim(),
                                    txtCity.Text.Trim(),
                                    DateTime.Now);

        Response.Redirect("SubscriberAdd.aspx?ID=True");
    }
    
    protected void LoadGroups()
    {
        dtGroups = taGroups.SelectAllGroups();
        ddlGroup.DataSource = dtGroups;
        ddlGroup.DataTextField = dtGroups.Columns[1].ToString();
        ddlGroup.DataValueField = dtGroups.Columns[0].ToString();
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, new ListItem("Please select one",""));
    }
}
