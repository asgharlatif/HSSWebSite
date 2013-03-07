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

public partial class admin_ProductImages : System.Web.UI.Page
{
    dsProductImageTableAdapters.ProductImageGalleryTableAdapter taProductImage = new dsProductImageTableAdapters.ProductImageGalleryTableAdapter();
    dsProductImage.ProductImageGalleryDataTable dtProductImage;
    
    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ProductId"] != null)
        {
            BindData();

            dtProduct = taProduct.SelectProductNamebyProductId(Convert.ToInt32(Request.QueryString["ProductId"]));
            if (dtProduct.Rows.Count > 0)
            {
                lblProductTitle.Text = "against " + dtProduct[0].ProductTitle.ToString();
            }
            else
            {
                btnAddImages.Visible = false;
                btnUpdateSortOrder.Visible = false;
                lblMsg.Text = "No record found";
                return;
            }
        }
        else
        {
            Response.Redirect("Product.aspx");
        }
    }
    public void BindData()
    {
        if (Request.QueryString["ProductId"] != null)
        {
            dtProductImage = taProductImage.SelectProductImagebyProductId(int.Parse(Request.QueryString["ProductId"].ToString()));
            if (dtProductImage.Rows.Count > 0)
            {
                DataList1.DataSource = dtProductImage;
                DataList1.DataBind();
            }
            else
            {
                btnUpdateSortOrder.Visible = false;
            }
        }
        else
            Response.Redirect("Product.aspx");
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            int ImageId = Convert.ToInt32(e.CommandArgument);
            taProductImage.DeleteProductImage(ImageId);
            BindData();
        }

        if (e.CommandName == "Edit")
        {
            int ImageId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ProductImagesEdit.aspx?ImageId=" + ImageId + "&ProductId=" + Request.QueryString["ProductId"]);

        }
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDel = (LinkButton)e.Item.FindControl("lbtnDelete");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this image?');");
        }
    }

    protected void btnAddImages_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductImagesAdd.aspx?ProductId=" + Request.QueryString["ProductId"]);
    }
    protected void btnUpdateSortOrder_Click(object sender, EventArgs e)
    {
        foreach (DataListItem Item in DataList1.Items)
        {
            Label lblImageId = (Label)Item.FindControl("lblImageId");
            TextBox txtSortOrder = (TextBox)Item.FindControl("txtSortOrder");
            taProductImage.UpdateProductImagesSortOrder(Convert.ToInt32(lblImageId.Text),
                                                    Convert.ToInt32(txtSortOrder.Text));
        }
        Response.Redirect("ProductImages.aspx?ProductId=" + Request.QueryString["ProductId"]);
    }
}
