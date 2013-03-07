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

public partial class admin_DownloadCategories : System.Web.UI.Page
{
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

        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            taCategory.DeleteDownloadCategory(categoryId);
            BindData();
        }
        if (e.CommandName == "Edit")
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("DownloadCategoryEdit.aspx?CategoryId=" + categoryId);
        }
        if (e.CommandName == "View")
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("DownloadSubCategories.aspx?CategoryId=" + categoryId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
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
        dtCategory = taCategory.SelectAllDownloadCategories();

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
}
