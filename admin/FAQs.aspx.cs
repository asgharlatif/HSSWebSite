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

public partial class admin_FAQs : System.Web.UI.Page
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
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Edited";
            }
        }

        SelectSections();

        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int QuestionId = Convert.ToInt32(e.CommandArgument);
            taFAQs.DeleteQuestions(QuestionId);
            BindData();
        }
        if (e.CommandName == "Edit")
        {
            int QuestionId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("FAQsEdit.aspx?QuestionId=" + QuestionId);
        }
        if (e.CommandName == "ChangeStatus")
        {
            int QuestionId = Convert.ToInt32(e.CommandArgument);
            taFAQs.ChangeQuestionStatus(QuestionId);
            BindData();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSectionId = (Label)e.Row.FindControl("lblSectionId");
            dtSections = taSections.SelectSectionsbySectionId(Convert.ToInt32(lblSectionId.Text));
            if (dtSections.Rows.Count > 0)
                lblSectionId.Text = dtSections[0].SectionName.ToString();
            else
                lblSectionId.Visible = false;

            LinkButton btnDel = (LinkButton)e.Row.FindControl("lbtnDelete");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");

            LinkButton btnEnable = (LinkButton)e.Row.FindControl("lbtnEnable");
            if (btnEnable.Text == "True")
                btnEnable.Text = "Inactive";
            else
                btnEnable.Text = "Active";
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
    private void BindData()
    {
        if (Request.QueryString["SectionId"] != null)
        {
            int SectionId = Convert.ToInt32(Request.QueryString["SectionId"]);
            dtFAQs = taFAQs.SelectQuestionsbySectionId(SectionId);
            ddlSection.Items.FindByValue(SectionId.ToString()).Selected = true;
        }
        else
            dtFAQs = taFAQs.SelectAllQuestions();

        if (dtFAQs.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtFAQs;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("FAQs.aspx?SectionId=" + ddlSection.SelectedItem.Value);
    }
}
