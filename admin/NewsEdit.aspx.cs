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

public partial class admin_NewsEdit : System.Web.UI.Page
{
    dsNewsTableAdapters.NewsTableAdapter taNews = new dsNewsTableAdapters.NewsTableAdapter();
    dsNews.NewsDataTable dtNews;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        SelectCategories();

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Edited";
            }
        }

        if (Request.QueryString["NewsId"] != null)
        {
            int newsId = Convert.ToInt32(Request.QueryString["NewsId"].ToString());
            dtNews = taNews.SelectNewsbyNewsId(newsId);
            if (dtNews.Rows.Count > 0)
            {
                ddlType.Items.FindByValue(dtNews[0].NewsCategoryId.ToString()).Selected = true;
                txtTitle.Text = dtNews[0].Title.ToString();
                txtStartDate.Text = dtNews[0].StartDate.ToString();
                txtShortDescription.Text = dtNews[0].ShortDescription.ToString();
                txtLongDescription.Text = dtNews[0].LongDescription.ToString();
                lblImage.Text = dtNews[0].MainImage.ToString();
                Image1.ImageUrl = "~/thumbnail.aspx?Image=Images/NewsImages/" + dtNews[0].MainImage.ToString() +"&size=100";
            }
        }
        else
        {
            btnEdit.Visible = false;
            lblMsg.Text = "No Record Found";
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string filename = "";

        if (FileUpload1.HasFile)
        {
            filename = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\NewsImages\\" + FileUpload1.FileName);
        }
        else
            filename = lblImage.Text;
        
        int newsId = Convert.ToInt32(Request.QueryString["NewsId"]);

        taNews.EditNews(newsId,
                        Convert.ToInt32(ddlType.SelectedItem.Value),
                        txtTitle.Text.Trim(),
                        Convert.ToDateTime(txtStartDate.Text.Trim()),
                        DateTime.Now,
                        txtShortDescription.Text.Trim(),
                        txtLongDescription.Text.Trim(),
                        filename);

        Response.Redirect("News.aspx?NewsId=" + newsId + "&ID=True");

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
