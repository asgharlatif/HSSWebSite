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

public partial class admin_FeedBackAdd : System.Web.UI.Page
{
    dsFeedBackTableAdapters.FeedbackTableAdapter taFeedBack = new dsFeedBackTableAdapters.FeedbackTableAdapter();
    dsFeedBack.FeedbackDataTable dtFeedBack;

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
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        taFeedBack.AddFeedBack(txtName.Text.Trim(),
                               txtEmail.Text.Trim(),
                               txtPhone.Text.Trim(),
                               txtCity.Text.Trim(),
                               txtOccupation.Text.Trim(),
                               txtCompany.Text.Trim(),
                               ddlAge.SelectedItem.Value,
                               txtComments.Text.Trim(),
                               DateTime.Now);

        Response.Redirect("FeedBackAdd.aspx?ID=True");
    }
}
