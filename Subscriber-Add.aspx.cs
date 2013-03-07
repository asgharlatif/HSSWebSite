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

public partial class Subscriber_Add : System.Web.UI.Page
{
    dsNewsLetterGroupsTableAdapters.GroupsTableAdapter taNewsLetterGroup = new dsNewsLetterGroupsTableAdapters.GroupsTableAdapter();
    dsNewsLetterGroups.GroupsDataTable dtNewsLetterGroup;
    dsSubscribersTableAdapters.SubscribersTableAdapter taSubscriber = new dsSubscribersTableAdapters.SubscribersTableAdapter();
    dsSubscribers.SubscribersDataTable dtSubscriber;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["Subscriber"] != null)
        {
            txtEmail.Text = Request.QueryString["Subscriber"];
        }
        else
        {
            //tblSubscriber.Visible = false;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dtNewsLetterGroup = taNewsLetterGroup.SelectFromGroupWhereTitleIsNone();
        if (dtNewsLetterGroup.Rows.Count > 0)
        {
            taSubscriber.AddSubscriber(Convert.ToInt32(dtNewsLetterGroup[0].GroupId.ToString()),
                                       txtEmail.Text.Trim(),
                                       txtName.Text.Trim(),
                                       txtAddress.Text.Trim(),
                                       ddlCity.SelectedItem.Text.Trim(),
                                       DateTime.Now);

        }
        Response.Redirect("Thankyou.aspx?ID=Subscribed");
    }
}
