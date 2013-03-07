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

public partial class admin_Sections : System.Web.UI.Page
{
    dsSectionsTableAdapters.SectionCategoryTableAdapter taCategory = new dsSectionsTableAdapters.SectionCategoryTableAdapter();
    dsSections.SectionCategoryDataTable dtCategory;

    dsSectionsTableAdapters.SectionsTableAdapter taSections = new dsSectionsTableAdapters.SectionsTableAdapter();
    dsSections.SectionsDataTable dtSections;

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

        SelectCategories();
       
        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int SectionId = Convert.ToInt32(e.CommandArgument);
            taSections.DeleteSections(SectionId);
            BindData();
        }
        if (e.CommandName == "Edit")
        {
            int SectionId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("SectionEdit.aspx?SectionId=" + SectionId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCategoryId = (Label)e.Row.FindControl("lblCategoryId");
            dtCategory = taCategory.SelectSectionCategorybyCategoryId(Convert.ToInt32(lblCategoryId.Text));
            if (dtCategory.Rows.Count > 0)
                lblCategoryId.Text = dtCategory[0].CategoryName.ToString();
            else
                lblCategoryId.Visible = false;

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

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Sections.aspx?CategoryId=" + ddlCategory.SelectedItem.Value);
    }
    protected void SelectCategories()
    {
        dtCategory = taCategory.SelectAllSectionCategories();
        ddlCategory.DataSourceID = null;
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataTextField = dtCategory.Columns[1].ToString();
        ddlCategory.DataValueField = dtCategory.Columns[0].ToString();
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Please Select", ""));
    }
    private void BindData()
    {
        if (Request.QueryString["CategoryId"] != null)
        {
            int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            dtSections = taSections.SelectSectionsbyCategoryId(CategoryId);
            ddlCategory.Items.FindByValue(CategoryId.ToString()).Selected = true;
        }
        else
            dtSections = taSections.SelectAllSections();

        if (dtSections.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtSections;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }
}
