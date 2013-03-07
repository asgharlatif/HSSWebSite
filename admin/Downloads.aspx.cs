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

public partial class admin_Downloads : System.Web.UI.Page
{
    dsDownloadsTableAdapters.DownloadsTableAdapter taDownloads = new dsDownloadsTableAdapters.DownloadsTableAdapter();
    dsDownloads.DownloadsDataTable dtDownloads;
    dsDownloadsTableAdapters.DownloadCategoriesTableAdapter taCategory = new dsDownloadsTableAdapters.DownloadCategoriesTableAdapter();
    dsDownloads.DownloadCategoriesDataTable dtCategory;

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
            int downloadId = Convert.ToInt32(e.CommandArgument);
            taDownloads.DeleteDownload(downloadId);
            BindData();
        }
        if (e.CommandName == "Edit")
        {
            int downloadId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("DownloadEdit.aspx?DownloadId=" + downloadId);
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
            dtDownloads = taDownloads.SelectDownloadbyCategoryId(categoryId);
            ddlCategory.Items.FindByValue(categoryId.ToString()).Selected = true;
        }
        else
            dtDownloads = taDownloads.SelectAllDownloads();

        if (dtDownloads.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtDownloads;
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
        dtCategory = taCategory.SelectDownloadCategoryandSubCategoryName();
        ddlCategory.DataSourceID = null;
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataTextField = dtCategory.Columns["CategoryName"].ToString();
        ddlCategory.DataValueField = dtCategory.Columns["SubCategoryId"].ToString();
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Please Select", ""));
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Downloads.aspx?CategoryId=" + ddlCategory.SelectedItem.Value);
    }
}
