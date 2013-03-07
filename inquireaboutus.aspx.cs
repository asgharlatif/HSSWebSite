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

public partial class inquireaboutus : System.Web.UI.Page
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
                              txtEmail1.Text.Trim(),
                              txtPhone.Text.Trim(),
                              txtCity.Text.Trim(),
                              txtOccupation.Text.Trim(),
                              txtCompany.Text.Trim(),
                              ddlAge.SelectedItem.Value,
                              txtComments1.Text.Trim(),
                              DateTime.Now);

        Server.Transfer("EmailTemplates/FeedbackEmailConfirmation.aspx");


    }

    public string Name
    {
        get { return txtName.Text.Trim(); }
    }
    public string Email
    {
        get { return txtEmail1.Text.Trim(); }
    }
    public string Phone
    {
        get { return txtPhone.Text.Trim(); }
    }
    public string City
    {
        get { return txtCity.Text.Trim(); }
    }
    public string Occupation
    {
        get { return txtOccupation.Text.Trim(); }
    }
    public string Company
    {
        get { return txtCompany.Text.Trim(); }
    }
    public string Age
    {
        get { return ddlAge.SelectedItem.Text; }
    }
    public string Comments
    {
        get { return txtComments1.Text.Trim(); }
    }
}