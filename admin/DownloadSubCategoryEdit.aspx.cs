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

public partial class admin_DownloadSubCategoryEdit : System.Web.UI.Page
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
                lblMsg.Text = "Successfully Edited";
            }
        }
        if (Request.QueryString["SubCategoryId"] != null)
        {
            int subCategoryId = Convert.ToInt32(Request.QueryString["SubCategoryId"]);
            dtSubCategory = taSubCategory.SelectDownloadCategorybyCategoryId(subCategoryId);

            if (dtSubCategory.Rows.Count > 0)
            {
                ddlCategory.Items.FindByValue(dtSubCategory[0].ParentId.ToString()).Selected = true;
                txtSubCategory.Text = dtSubCategory[0].Title.ToString(); 
            }
            else
            {
                lblMsg.Text = "No Record Found";
                btnEdit.Visible = false;
                return;
            }
        }
        else
        {
            lblMsg.Text = "No Record Found";
            btnEdit.Visible = false;
            return;
        }

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int subCategoryId = Convert.ToInt32(Request.QueryString["SubCategoryId"]);
        taSubCategory.EditDownloadSubCategories(Convert.ToInt32(ddlCategory.SelectedItem.Value),
                                                Convert.ToInt32(subCategoryId),
                                                txtSubCategory.Text.Trim());

        Response.Redirect("DownloadSubCategories.aspx?ID=True&SubCategoryId=" + subCategoryId);
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
