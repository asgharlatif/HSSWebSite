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

public partial class admin_FAQsAdd : System.Web.UI.Page
{
    dsSectionsTableAdapters.SectionsTableAdapter taSections = new dsSectionsTableAdapters.SectionsTableAdapter();
    dsSections.SectionsDataTable dtSections;

    dsFAQTableAdapters.FAQTableAdapter taFAQs = new dsFAQTableAdapters.FAQTableAdapter();
    dsFAQ.FAQDataTable dtFAQs;

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

        SelectSections();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        taFAQs.AddQuestions(Convert.ToInt32(ddlSection.SelectedItem.Value),
                            txtQuestion.Text.Trim(),
                            txtAnswer.Text.Trim(),
                            Convert.ToInt32(txtSortOrder.Text),
                            true,
                            DateTime.Now);

        Response.Redirect("FAQsAdd.aspx?ID=True");
    }
    protected void SelectSections()
    {
        dtSections = taSections.SelectSectionCategoryAndSectionName();
        ddlSection.DataSourceID = null;
        ddlSection.DataSource = dtSections;
        ddlSection.DataTextField = dtSections.Columns["SectionName"].ToString();
        ddlSection.DataValueField = dtSections.Columns["SectionId"].ToString();
        ddlSection.DataBind();
        ddlSection.Items.Insert(0, new ListItem("Please Select", ""));
    }
}
