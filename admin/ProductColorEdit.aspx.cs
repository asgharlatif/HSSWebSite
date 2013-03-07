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

public partial class admin_ProductColorEdit : System.Web.UI.Page
{
    dsProductColorsTableAdapters.ProductColorsImagesTableAdapter taProductColors = new dsProductColorsTableAdapters.ProductColorsImagesTableAdapter();
    dsProductColors.ProductColorsImagesDataTable dtProductColors;

    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;

    dsColorsTableAdapters.ColorsTableAdapter taColors = new dsColorsTableAdapters.ColorsTableAdapter();
    dsColors.ColorsDataTable dtColors;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        LoadColors();

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Edited";
            }
        }

        if (Request.QueryString["ProductColorId"] != null)
        {
            int productColorId = Convert.ToInt32(Request.QueryString["ProductColorId"]);
            dtProductColors = taProductColors.SelectProductColorByProductColorId(productColorId);
            if (dtProductColors.Rows.Count > 0)
            {
                int productId = Convert.ToInt32(dtProductColors[0].ProductId);
                dtProduct = taProduct.SelectProductNamebyProductId(productId);
                if (dtProduct.Rows.Count > 0)
                {
                    lblProductTitle.Text = dtProduct[0].ProductTitle.ToString();
                    ddlColors.Items.FindByValue(dtProductColors[0].ColorId.ToString()).Selected = true;
                    txtSortOrder.Text = dtProductColors[0].Sort.ToString();
                    lblImage.Text = dtProductColors[0].Image.ToString();
                    if (lblImage.Text != "")
                    {
                        Image1.ImageUrl = "~/thumbnail.aspx?image=Images/ProductColorImages/" + lblImage.Text + "&size=150";
                    }
                }
                else
                {
                    lblMsg.Text = "No product found against the provide productcolorid";
                    tblColor.Visible = false;
                }   

            }
            else
            {
                lblMsg.Text = "No record found";
                tblColor.Visible = false;
            }
        }
        else
        {
            lblMsg.Text = "No record found";
            tblColor.Visible = false;
        }
    }
    protected void LoadColors()
    {
        dtColors = taColors.SelectAllColors();
        if (dtColors.Rows.Count > 0)
        {
            ddlColors.DataSource = dtColors;
            ddlColors.DataTextField = dtColors.Columns[1].ToString();
            ddlColors.DataValueField = dtColors.Columns[0].ToString();
            ddlColors.DataBind();
            ddlColors.Items.Insert(0, new ListItem("Please Select", ""));
        }

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int productColorId =  Convert.ToInt32(Request.QueryString["ProductColorId"]);

        string fileName = "";
        if (FileUpload1.HasFile)
        {
            fileName = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductColorImages\\" + fileName);
        }
        else
        {
            fileName = lblImage.Text;
        }

        taProductColors.EditProductColors(productColorId,
                                          Convert.ToInt32(ddlColors.SelectedItem.Value),
                                          fileName,
                                          Convert.ToInt32(txtSortOrder.Text));

        Response.Redirect("ProductColors.aspx?ID=True&ProductColorId=" + productColorId.ToString());
                                          
    }
}
   
