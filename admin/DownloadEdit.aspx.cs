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

public partial class admin_DownloadEdit : System.Web.UI.Page
{
    dsDownloadsTableAdapters.DownloadsTableAdapter taDownloads = new dsDownloadsTableAdapters.DownloadsTableAdapter();
    dsDownloads.DownloadsDataTable dtDownloads;
    dsDownloadsTableAdapters.DownloadCategoriesTableAdapter taCategory = new dsDownloadsTableAdapters.DownloadCategoriesTableAdapter();
    dsDownloads.DownloadCategoriesDataTable dtCategory;

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
        
        if (Request.QueryString["DownloadId"] != null)
        {
            int downloadId = Convert.ToInt32(Request.QueryString["DownloadId"]);
            dtDownloads = taDownloads.SelectDownloadbyDownloadId(downloadId);

            if (dtDownloads.Rows.Count > 0)
            {
                ddlCategory.Items.FindByValue(dtDownloads[0].CategoryId.ToString()).Selected = true;
                txtTitle.Text = dtDownloads[0].Title.ToString();
                lblUpload.Text = dtDownloads[0].Upload.ToString();
                Image1.ImageUrl = "~/thumbnail.aspx?Image=Images/Downloads/" + lblUpload.Text + "&size=100";
                txtExternalLink.Text = dtDownloads[0].ExternalLink.ToString();
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
            int random = RandomNumber(0, 999999999); 
            string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
            filename = random + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()
                                + DateTime.Now.Second.ToString()
                                + DateTime.Now.Millisecond.ToString() + ext;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\Downloads\\" + filename);
        }
        else
            filename = lblUpload.Text;

        taDownloads.EditDownload(Convert.ToInt32(Request.QueryString["DownloadId"]),
                                Convert.ToInt32(ddlCategory.SelectedItem.Value),
                                txtTitle.Text.Trim(),
                                filename,
                                txtExternalLink.Text.Trim());

        Response.Redirect("Downloads.aspx?ID=True&DownloadId=" + Request.QueryString["DownloadId"]);
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
    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}
