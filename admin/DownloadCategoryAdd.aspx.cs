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

public partial class admin_DownloadCategoryAdd : System.Web.UI.Page
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
                lblMsg.Text = "Successfully Added";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string filename = "";
        
            
        if (FileUpload1.HasFile)
        {
            filename = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\DownloadCategoryImages\\" + FileUpload1.FileName);
        }
        
        
        taCategory.AddDownloadCategory(txtCategory.Text.Trim(), 
                                       DateTime.Now,
                                       filename);
        Response.Redirect("DownloadCategoryAdd.aspx?ID=True");
    }
    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}
