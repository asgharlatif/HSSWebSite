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

public partial class admin_ProductImagesEdit : System.Web.UI.Page
{
    dsProductImageTableAdapters.ProductImageGalleryTableAdapter taProductImage = new dsProductImageTableAdapters.ProductImageGalleryTableAdapter();
    dsProductImage.ProductImageGalleryDataTable dtProductImage;

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

        if (Request.QueryString["ImageId"] != null)
        {
            dtProductImage = taProductImage.SelectProductImagebyImageId(Convert.ToInt32(Request.QueryString["ImageId"]));

            if (dtProductImage.Rows.Count > 0)
            {
                DataRow row = dtProductImage.Rows[0];
                Image1.ImageUrl = "~/thumbnail.aspx?Image=Images/ProductImages/" + row["Image"].ToString() + "&size=100";
                lblLargeImage.Text = row["Image"].ToString();
                txtSortOrder.Text = row["Sort"].ToString();
                txtTitle.Text = row["Title"].ToString();
                txtDescription.Text = row["Description"].ToString();

            }
            else
            {
                tblProductImage.Visible = false;
                lblMsg.Text = "Image Details not found";
            }
        }
        else
        {
            tblProductImage.Visible = false;
            lblMsg.Text = "Image Details not found";
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string filename1 = "";
        if (FileUpload1.HasFile)
        {
            filename1 = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductImages\\" + FileUpload1.FileName);
        }
        else
            filename1 = lblLargeImage.Text;

        taProductImage.EditProductImage(Convert.ToInt32(Request.QueryString["ImageId"]),
                                       Convert.ToInt32(txtSortOrder.Text.Trim()),
                                        filename1,
                                        txtTitle.Text.Trim(),
                                        txtDescription.Text.Trim());

        Response.Redirect("ProductImages.aspx?ProductId=" + Request.QueryString["ProductId"]);

    }
}
