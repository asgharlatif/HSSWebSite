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

public partial class admin_DownloadSubCategoryAdd : System.Web.UI.Page
{
    dsDownloadsTableAdapters.DownloadCategoriesTableAdapter taCategory = new dsDownloadsTableAdapters.DownloadCategoriesTableAdapter();
    dsDownloads.DownloadCategoriesDataTable dtCategory;
    dsDownloadsTableAdapters.DownloadCategoriesTableAdapter taSubCategory = new dsDownloadsTableAdapters.DownloadCategoriesTableAdapter();
    dsDownloads.DownloadCategoriesDataTable dtSubCategory;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        SelectCategories();

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Added";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        taSubCategory.AddDownloadSubCategory(Convert.ToInt32(ddlCategory.SelectedItem.Value),
                                             txtSubCategory.Text.Trim(),
                                             DateTime.Now);

        Response.Redirect("DownloadSubCategoryAdd.aspx?ID=True");
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
}
