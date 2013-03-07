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

public partial class admin_ManageCompanyProducts : System.Web.UI.Page
{
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                //lblMsg.Visible = true;
                //lblMsg.Text = "Successfully Edited";
            }
        }


        if (Request.QueryString["companyid"] != null)
        {
            int companyid = Convert.ToInt32(Request.QueryString["companyid"]);
            dtCompany = taCompany.SelectAllCompanyByCompanyId(companyid);

            if (dtCompany.Rows.Count > 0)
            {
                    DataRow row = dtCompany.Rows[0];
                    lblCompany.Text = row["CompanyName"].ToString();
            }

        }

        BindData();

    }

   
    private void BindData()
    {

        if (Request.QueryString["CompanyId"] != null)
        {
            int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
            dtProduct = taProduct.SelectProductsCompanyWise(CompanyId);
            ddlCompany.Items.FindByValue(CompanyId.ToString()).Selected = true;
        }
        else
            dtProduct = taProduct.GetData();

        
        if (dtProduct.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtProduct;

            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtProduct;
            GridView1.DataBind();

            
            return;
        }
        
    }
}