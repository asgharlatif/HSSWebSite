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

public partial class admin_News : System.Web.UI.Page
{
   
    dsNewsTableAdapters.NewsCategoryTableAdapter taNewsCategory = new dsNewsTableAdapters.NewsCategoryTableAdapter();
    dsNews.NewsCategoryDataTable dtNewsCategory;
    dsNewsTableAdapters.NewsTableAdapter taNews = new dsNewsTableAdapters.NewsTableAdapter();
    dsNews.NewsDataTable dtNews;

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
        dtNews = taNews.SelectAllNews();
        if (dtNews.Rows.Count > 0)
        {
            GridView1.DataSource = dtNews;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "No record found";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int newsId = Convert.ToInt32(e.CommandArgument);
            taNews.DeleteNews(newsId);
            BindData();
        }

        if (e.CommandName == "EditItem")
        {
            int newsId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("NewsEdit.aspx?NewsId=" + newsId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDel = (LinkButton)e.Row.FindControl("delbutton");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");

            Label lblNewsCategoryId = (Label)e.Row.FindControl("lblNewsCategoryId");
            dtNewsCategory = taNewsCategory.SelectNewsCategoryNameByNewsCategoryId(Convert.ToInt32(lblNewsCategoryId.Text));
            if (dtNewsCategory.Rows.Count > 0)
                lblNewsCategoryId.Text = dtNewsCategory[0].NewsCategoryTitle.ToString();

        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}
