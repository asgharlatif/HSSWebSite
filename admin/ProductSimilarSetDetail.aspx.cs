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

public partial class admin_ProductSimilarSetDetail : System.Web.UI.Page
{
    SimilarSetTableAdapters.ProductSimilarSetTableAdapter taSimilarSet = new SimilarSetTableAdapters.ProductSimilarSetTableAdapter();
    SimilarSet.ProductSimilarSetDataTable dtSimilarSet;

    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;
    

    dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
    dsCategory.CategoryDataTable dtCategory;


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


        if (Request.QueryString["SetCode"] != null)
        { 

            int SetCode=Convert.ToInt16(Request.QueryString["SetCode"]);
            int CompanyId = Convert.ToInt16(taSimilarSet.SelectCompanyIdUsingSetCode(SetCode));

            lblCompNameName.Text = taCompany.SelectSingleCompanyNameUsingCompanyId(CompanyId); 
            lblSetName.Text= "[ " + taSimilarSet.SelectSetDescription(SetCode).ToString() + " ] ";
        }
       

        
        BindData();
    }

   
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("ProductSimilarSetDetail.aspx?SetCode=" + Request.QueryString["SetCode"] );
    }
    private void BindData()
    {
        int SetCode=Convert.ToInt16(Request.QueryString["SetCode"]);
        int CompanyId =Convert.ToInt16( taSimilarSet.SelectCompanyIdUsingSetCode(SetCode));
        dtProduct = taProduct.SelectUnSetProduct(CompanyId, SetCode);
           
       

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

            lblMsg.Text = "No record found";
            return;
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        if (e.CommandName == "IsSetCodePresent")
        {
            
            int ProductId = Convert.ToInt32(e.CommandArgument);
            int SetCode = Convert.ToInt16(Request.QueryString["SetCode"]);
            
            taProduct.ChangeProductSetCode(ProductId, SetCode);
            BindData();
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblCategoryId = (Label)e.Row.FindControl("lblCategoryId");
            dtCategory = taCategory.SelectCategorybyCategoryId(Convert.ToInt32(lblCategoryId.Text));
            if (dtCategory.Rows.Count > 0)
                lblCategoryId.Text = dtCategory[0].CategoryName.ToString();


            LinkButton lbtnManageSetCode = (LinkButton)e.Row.FindControl("lbtnManageSetCode");

            

            if (lbtnManageSetCode.Text == null || lbtnManageSetCode.Text == "")
                lbtnManageSetCode.Text = "Include in this Set";
            else
                lbtnManageSetCode.Text = "Remove from this Set";

        }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}