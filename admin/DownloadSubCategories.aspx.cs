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

public partial class admin_DownloadSubCategories : System.Web.UI.Page
{
    dsDownloadsTableAdapters.DownloadCategoriesTableAdapter taCategory = new dsDownloadsTableAdapters.DownloadCategoriesTableAdapter();
    dsDownloads.DownloadCategoriesDataTable dtCategory;
    dsDownloadsTableAdapters.DownloadCategoriesTableAdapter taSubCategory = new dsDownloadsTableAdapters.DownloadCategoriesTableAdapter();
    dsDownloads.DownloadCategoriesDataTable dtSubCategory;

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

        SelectCategories();

        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            taSubCategory.DeleteDownloadCategory(categoryId);
            BindData();
        }
        if (e.CommandName == "Edit")
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("DownloadSubCategoryEdit.aspx?SubCategoryId=" + categoryId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCategoryId = (Label)e.Row.FindControl("lblCategoryId");
            dtCategory = taCategory.SelectDownloadCategoryNamebyCategoryId(Convert.ToInt32(lblCategoryId.Text));
            if (dtCategory.Rows.Count > 0)
                lblCategoryId.Text = dtCategory[0].Title.ToString();
            else
                lblCategoryId.Visible = false;

            LinkButton btnDel = (LinkButton)e.Row.FindControl("lbtnDelete");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    private void BindData()
    {
        if (Request.QueryString["CategoryId"] != null)
        {
            int categoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            dtSubCategory = taSubCategory.SelectDownloadSubCategoriesbyParentId(categoryId);
            ddlCategory.Items.FindByValue(categoryId.ToString()).Selected = true;
        }
        else
            dtSubCategory = taSubCategory.SelectAllDownloadSubCategories();

        if (dtSubCategory.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtSubCategory;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }

    protected void SelectCategories()
    {
        dtCategory = taCategory.SelectAllDownloadCategories();
        ddlCategory.DataSourceID = null;
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataTextField = dtCategory.Columns["Title"].ToString();
        ddlCategory.DataValueField = dtCategory.Columns["CategoryId"].ToString();
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Please Select", ""));
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("DownloadSubCategories.aspx?CategoryId=" + ddlCategory.SelectedItem.Value);
    }
}
