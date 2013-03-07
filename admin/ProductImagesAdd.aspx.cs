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

public partial class admin_ProductImagesAdd : System.Web.UI.Page
{

    dsProductImageTableAdapters.ProductImageGalleryTableAdapter taProductImage = new dsProductImageTableAdapters.ProductImageGalleryTableAdapter();
    dsProductImage.ProductImageGalleryDataTable dtProductImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ProductId"] == null)
        {
            tblProductImage.Visible = false;
            lblMsg.Text = "Sorry you cannot add an image";
            //return;
        }
        else
        {

            dtProductImage = taProductImage.SelectProductNamebyProductId(Convert.ToInt32(Request.QueryString["ProductId"]));

            if (dtProductImage.Rows.Count > 0)
                lblProductName.Text = dtProductImage.Rows[0]["ProductTitle"].ToString();
            else
            {
                tblProductImage.Visible = false;
                lblMsg.Text = "Sorry you cannot add an image";
            }
        }
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
        taProductImage.AddProductImage(Convert.ToInt32(Request.QueryString["ProductId"]),
                                        Convert.ToDecimal(txtSortOrder.Text.Trim()),
                                        FileUpload1.FileName,
                                        txtTitle.Text.Trim(),
                                        txtDescription.Text.Trim());

        FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductImages\\" + FileUpload1.FileName);
        Response.Redirect("ProductImages.aspx?ProductId=" + Request.QueryString["ProductId"]);
    }
}
