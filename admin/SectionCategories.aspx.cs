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

public partial class admin_SectionCategories : System.Web.UI.Page
{
    dsSectionsTableAdapters.SectionCategoryTableAdapter taCategory = new dsSectionsTableAdapters.SectionCategoryTableAdapter();
    dsSections.SectionCategoryDataTable dtCategory;

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

        BindData();
    }
    private void BindData()
    {
        dtCategory = taCategory.SelectAllSectionCategories();
        if (dtCategory.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtCategory;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int CategoryId = Convert.ToInt32(e.CommandArgument);
            taCategory.DeleteSectionCategory(CategoryId);
            BindData();
        }

        if (e.CommandName == "Edit")
        {
            int CategoryId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("SectionCategoryEdit.aspx?CategoryId=" + CategoryId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}
