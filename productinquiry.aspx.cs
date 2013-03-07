using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class productinquiry : System.Web.UI.Page
{
    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;
    dsProduct.ProductDataTable dtSimilarProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        int ProductId =Convert.ToInt16( Request.QueryString["ProductId"]);

        dtProduct = taProduct.SelectProductbyProductId(ProductId);

        if (dtProduct.Rows.Count > 0)
        {
            DataRow row = dtProduct.Rows[0];

            lblProductName.Text = row["ProductTitle"].ToString();
            lblCompName.Text = "DYL";// taProduct.SelectCompanyNameUsingProductId(ProductId);
            lblModel.Text = row["Model"].ToString();
            lblPartNumber.Text = row["ProductId"].ToString();
            txtProductDescription.Text = row["description"].ToString();

            ProductImage.ImageUrl = "~/thumbnail.aspx?Image=Images/ProductMainImages/" + row["MainImage"].ToString(); //+ "&size=200";

            ItemsGet();
           // IsThisProductExistInCart();
        }
        
    }
   

    private void ItemsGet()
    {
        int ProductId = Convert.ToInt16(Request.QueryString["ProductId"]);
        dtSimilarProduct = taProduct.SelectSimilarProductbyProductId(ProductId);
        if (dtProduct.Rows.Count > 0)
        {
            Repeater1.DataSource = dtSimilarProduct;
            Repeater1.DataBind();
        }
    }        
    
}