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

public partial class admin_FAQsEdit : System.Web.UI.Page
{
    dsSectionsTableAdapters.SectionsTableAdapter taSections = new dsSectionsTableAdapters.SectionsTableAdapter();
    dsSections.SectionsDataTable dtSections;

    dsFAQTableAdapters.FAQTableAdapter taFAQs = new dsFAQTableAdapters.FAQTableAdapter();
    dsFAQ.FAQDataTable dtFAQs;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        SelectSections();

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Edited";
            }
        }

        if (Request.QueryString["QuestionId"] != null)
        {
            int QuestionId = Convert.ToInt32(Request.QueryString["QuestionId"]);
            dtFAQs = taFAQs.SelectQuestionsbyQuestionId(QuestionId);
            if (dtFAQs.Rows.Count > 0)
            {
                ddlSection.Items.FindByValue(dtFAQs[0].SectionId.ToString()).Selected = true;
                txtQuestion.Text = dtFAQs[0].Question.ToString();
                txtAnswer.Text = dtFAQs[0].Answer.ToString();
                txtSortOrder.Text = dtFAQs[0].Sort.ToString();
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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        taFAQs.EditQuestions(Convert.ToInt32(Request.QueryString["QuestionId"]),
                             Convert.ToInt32(ddlSection.SelectedItem.Value),
                             txtQuestion.Text.Trim(),
                             txtAnswer.Text.Trim(),
                             Convert.ToInt32(txtSortOrder.Text.Trim()));

        Response.Redirect("FAQs.aspx?QuestionId=" + Request.QueryString["QuestionId"] + "&ID=True");
                             
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
