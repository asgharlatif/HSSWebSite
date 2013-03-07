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

public partial class admin_ProductColorAdd : System.Web.UI.Page
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
                lblMsg.Text = "Successfully Added";
            }
        }
        if (Request.QueryString["ProductId"] != null)
        {
            int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
            dtProduct = taProduct.SelectProductNamebyProductId(productId);
            if (dtProduct.Rows.Count > 0)
            {
                lblProductTitle.Text = dtProduct[0].ProductTitle.ToString();
                lblProductId.Text = productId.ToString();
            }
            else
            {
                lblMsg.Text = "No product found against the provide productid";
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
            ddlColors.Items.Insert(0,new ListItem("Please Select",""));
        }
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string fileName = "";
        if (FileUpload1.HasFile)
        {
            fileName = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductColorImages\\" + fileName);
        }
        taProductColors.AddProductColors(Convert.ToInt32(lblProductId.Text),
                                         Convert.ToInt32(ddlColors.SelectedItem.Value),
                                         fileName,
                                         Convert.ToInt32(txtSortOrder.Text),
                                         DateTime.Now);

        Response.Redirect("ProductColors.aspx?ProductId=" + lblProductId.Text);
    }
}
