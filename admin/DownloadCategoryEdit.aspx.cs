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

public partial class admin_DownloadCategoryEdit : System.Web.UI.Page
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

        if (Request.QueryString["CategoryId"] != null)
        {
            int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            dtCategory = taCategory.SelectDownloadCategorybyCategoryId(CategoryId);

            if (dtCategory.Rows.Count > 0)
            {
                txtCategory.Text = dtCategory[0].Title.ToString();
                lblImage.Text = dtCategory[0].Image.ToString();
                if (lblImage.Text != "")
                    Image1.ImageUrl = "~/thumbnail.aspx?Image=Images/DownloadCategoryImages/" + lblImage.Text + "&size=100";
                else
                    Image1.Visible = false;
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
        string filename = "";

        if (FileUpload1.HasFile)
        {
            filename = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\DownloadCategoryImages\\" + FileUpload1.FileName);
        }
        else
            filename = lblImage.Text;

        int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
        taCategory.EditDownloadCategories(CategoryId,
                                          txtCategory.Text.Trim(),
                                          filename);

        Response.Redirect("DownloadCategories.aspx?ID=True&CategoryId=" + CategoryId);
    }

}