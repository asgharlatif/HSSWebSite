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

public partial class admin_NewsAdd : System.Web.UI.Page
{
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
                lblMsg.Text = "Successfully Added";
            }
        }

        SelectCategories();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string fileName = "";

        fileName = FileUpload1.FileName;
        FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\NewsImages\\" + fileName);

        taNews.AddNews(Convert.ToInt32(ddlType.SelectedItem.Value),
                       txtTitle.Text.Trim(),
                       Convert.ToDateTime(txtStartDate.Text.Trim()),
                       DateTime.Now,
                       txtShortDescription.Text.Trim(),
                       txtLongDescription.Text.Trim(),
                       fileName);

        Response.Redirect("NewsAdd.aspx?ID=True");
    }

    public void SelectCategories()
    {
        dsNewsTableAdapters.NewsCategoryTableAdapter taNewsCategory = new dsNewsTableAdapters.NewsCategoryTableAdapter();
        dsNews.NewsCategoryDataTable dtNewsCategory;
        dtNewsCategory = taNewsCategory.SelectAllNewsCategories();
        ddlType.DataSourceID = null;
        ddlType.DataSource = dtNewsCategory;
        ddlType.DataTextField = dtNewsCategory.Columns[1].ToString();
        ddlType.DataValueField = dtNewsCategory.Columns[0].ToString();
        ddlType.DataBind();
        ddlType.Items.Insert(0, new ListItem("Please Select", ""));
    }
}