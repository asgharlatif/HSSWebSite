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
using ClassP;

public partial class admin_ProductAdd : System.Web.UI.Page
{

    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;

    dsTechnicalSpecsTableAdapters.TechnicalSpecsTableAdapter taTechnicalSpecs = new dsTechnicalSpecsTableAdapters.TechnicalSpecsTableAdapter();
    dsTechnicalSpecs.TechnicalSpecsDataTable dtTechnicalSpecs;


    dsBas_BrandsTableAdapters.Bas_BrandsTableAdapter dsBas_Brands = new dsBas_BrandsTableAdapters.Bas_BrandsTableAdapter();
    dsBas_Brands.Bas_BrandsDataTable dtBas_Brands;

    dsBas_WarrantiesTableAdapters.Bas_WarrantiesTableAdapter dsBas_Warranties = new dsBas_WarrantiesTableAdapters.Bas_WarrantiesTableAdapter();
    dsBas_Warranties.Bas_WarrantiesDataTable dtBas_Warranties;

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

        LoadCompanies();
        SelectCategories();
        SelectSubCategories();
        SelectProductGroups();
        LoadDropDownLists();
        LoadProductInformationToEdit();

    }

    private void LoadProductInformationToEdit()
    {
        if (Request.QueryString["ProductId"] != null && Convert.ToInt16( Request.QueryString["ProductId"]) != 0)
        {
            lblPageFunction.Text = "Edit Product";
            btnAdd.Text = "Update";
            ddlCompany.Enabled = false;
            ddlCategory.Enabled = false;
            ddlSubCategory.Enabled = false;
            ddlProductGroup.Enabled = false;

            dtProduct = taProduct.SelectProductbyProductId(Convert.ToInt32(Request.QueryString["ProductId"]));

            if (dtProduct.Rows.Count > 0)
            {
                DataRow row = dtProduct.Rows[0];
                Image1.ImageUrl = "~/thumbnail.aspx?Image=Images/ProductMainImages/" + row["MainImage"].ToString() + "&size=100";  
                ImageTN.ImageUrl = "~/thumbnail.aspx?Image=Images/ProductThumbNail/" + row["ThumbNail"].ToString() + "&size=100";
                txtSortOrder.Text = row["Sort"].ToString();
                txtTitle.Text = row["ProductTitle"].ToString();
                txtDescription.Text = row["Description"].ToString();
                txtModel.Text = row["Model"].ToString();
                txtTechnicalSpecs.Text = row["TechnicalSpecs"].ToString();
                txtDownloadInformation.Text = row["DownloadInformation"].ToString();
                txtVideoLink.Text = row["VideoLink"].ToString();
                
                lblVideoImage.Text = row["VideoLinkImage"].ToString();
                lblLargeImage.Text = row["MainImage"].ToString();
                lblLargeImageTN.Text = row["ThumbNail"].ToString();

                txtPartNumber.Text = row["PartNumber"].ToString();

                ddlBas_Brands.Items.FindByValue(row["Br_Code"].ToString()).Selected = true;
                ddlBas_Warranties.Items.FindByValue(row["WarCode"].ToString()).Selected = true;
                
                if (lblVideoImage.Text != "")
                    VideoImage.ImageUrl = "~/thumbnail.aspx?Image=Images/ProductVideoImages/" + lblVideoImage.Text + "&size=100";
                else
                    VideoImage.Visible = false;

            }
            
        }
        
    }

    private void LoadDropDownLists()
    {
        
        FillWebControlClass FCC = new FillWebControlClass();
                
        //drop down filling through method 1
        dtBas_Brands=dsBas_Brands.GetData();
        FCC.FillDropDownList(ref ddlBas_Brands, dtBas_Brands, "Br_Name", "Br_Code");

        //drop down filling through method 2
        connectionstring concls = new connectionstring();
        ylibWebClass ylib = new ylibWebClass(concls.connect());
        FCC.FillDropDownList(ref ddlBas_Warranties,ylib.GiveDataTable_BySQLStatement("select WarCode,WatName from Bas_Warranties"), "WatName", "WarCode");
        
    }

    protected void SelectProductGroups()
    {
        int SubCategoryId = 0;
        int CategoryId;
        
        
        dsProductGroupTableAdapters.ProductGroupTableAdapter taProductGroup = new dsProductGroupTableAdapters.ProductGroupTableAdapter();
        dsProductGroup.ProductGroupDataTable dtProductGroup;

        int ProductGroupCode = Convert.ToInt32(Request.QueryString["ProductGroupCode"]);

        CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
        SubCategoryId = Convert.ToInt32(Request.QueryString["SubCategoryId"]);


        if ((Request.QueryString["CompanyId"] != null) && (Convert.ToInt16(Request.QueryString["CompanyId"]) != 0) && CategoryId != 0 && SubCategoryId !=0)
        {
            dtProductGroup = taProductGroup.GetDataBySubCategoryId(SubCategoryId);
            ddlSubCategory.Items.FindByValue(SubCategoryId.ToString()).Selected = true;
            
        }
        else
            dtProductGroup = taProductGroup.GetDataBySubCategoryId(SubCategoryId);

        ddlProductGroup.DataSourceID = null;
        ddlProductGroup.DataSource = dtProductGroup;
        ddlProductGroup.DataTextField = dtProductGroup.Columns[2].ToString();
        ddlProductGroup.DataValueField = dtProductGroup.Columns[1].ToString();
        ddlProductGroup.DataBind();

        if ((Request.QueryString["ProductGroupCode"] != null) && (Convert.ToInt16(Request.QueryString["ProductGroupCode"]) != 0))
        {
            ddlProductGroup.Items.FindByValue(Request.QueryString["ProductGroupCode"]).Selected = true;
        }
        else
            ddlProductGroup.Items.Insert(0, new ListItem("Please Select", ""));

    }

    protected void SelectSubCategories()
    {
        int CategoryId = 0;
        dsSubCategoryTableAdapters.SubCategoryTableAdapter taSubCategory = new dsSubCategoryTableAdapters.SubCategoryTableAdapter();
        dsSubCategory.SubCategoryDataTable dtSubCategory;
                                                                 
        int SubCategoryId = Convert.ToInt32(Request.QueryString["SubCategoryId"]);
        CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);

        if ((Request.QueryString["CompanyId"] != null) && (Convert.ToInt16(Request.QueryString["CompanyId"]) != 0) && CategoryId != 0)
        {
            dtSubCategory = taSubCategory.GetDataByCategoryId(CategoryId);
            ddlCategory.Items.FindByValue(CategoryId.ToString()).Selected = true;
        }
        else
            dtSubCategory = taSubCategory.GetDataByCategoryId(CategoryId);

        ddlSubCategory.DataSourceID = null;
        ddlSubCategory.DataSource = dtSubCategory;
        ddlSubCategory.DataTextField = dtSubCategory.Columns[2].ToString();
        ddlSubCategory.DataValueField = dtSubCategory.Columns[1].ToString();
        ddlSubCategory.DataBind();

        if ((Request.QueryString["SubCategoryId"] != null) && (Convert.ToInt16(Request.QueryString["SubCategoryId"]) != 0))
        {
            ddlSubCategory.Items.FindByValue(Request.QueryString["SubCategoryId"]).Selected = true;
        }
        else
            ddlSubCategory.Items.Insert(0, new ListItem("Please Select", ""));
        
    }

    protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("ProductAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value + "&ProductGroupCode=" + ddlProductGroup.SelectedItem.Value);
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("ProductAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value + "&SubCategoryId=" + ddlSubCategory.SelectedItem.Value);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProductAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value + "&CategoryId=" + ddlCategory.SelectedItem.Value);
    }
    protected void LoadCompanies()
    {

        dtCompany = taCompany.SelectAllCompany();
        ddlCompany.DataSource = dtCompany;
        ddlCompany.DataTextField = dtCompany.Columns[1].ToString();
        ddlCompany.DataValueField = dtCompany.Columns[0].ToString();
        ddlCompany.DataBind();
        ddlCompany.Items.Insert(0, new ListItem("Please select one", ""));
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string fileName1 = "";
        string fileNameTN = "";
        string fileName3 = "";

        if (FileUpload1.HasFile)
        {
            fileName1 = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductMainImages\\" + FileUpload1.FileName);
        }
        else
            fileName1 = lblLargeImage.Text;


        if (FileUpload4.HasFile)
        {
            fileName3 = FileUpload4.FileName;
            FileUpload4.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductVideoImages\\" + FileUpload4.FileName);
        }
        else
            fileName3 = lblVideoImage.Text;

        
        if (FileUploadTN.HasFile)
         {
             fileNameTN = FileUploadTN.FileName;
             FileUploadTN.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\ProductThumbNail\\" + FileUploadTN.FileName);
         }
         else
            fileNameTN = lblLargeImageTN.Text;

        int ProductIdQ = 0;
            ProductIdQ= Convert.ToInt16(Request.QueryString["ProductId"]);

         int ProductId = Convert.ToInt32(taProduct.AddProduct(Convert.ToInt32(ddlProductGroup.SelectedItem.Value),
                            txtTitle.Text.Trim(),
                            Convert.ToDecimal(txtSortOrder.Text.Trim()),
                            txtDescription.Text.Trim(),
                            txtModel.Text.Trim(),
                            fileName1,
                            txtTechnicalSpecs.Text.Trim(),
                            DateTime.Now,
                            false,
                            txtDownloadInformation.Text.Trim(),      
                            Convert.ToInt32(ddlBas_Brands.SelectedItem.Value),
                            Convert.ToInt32(ddlBas_Warranties.SelectedItem.Value),
                            txtPartNumber.Text.Trim(),
                            txtVideoLink.Text.Trim(),
                            fileName3,
                            fileNameTN,
                            ProductIdQ));

        taTechnicalSpecs.AddSpecs(ProductId,
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "",
                                  "");


        if (ProductIdQ != 0)
            Response.Redirect("Products.aspx");
        else
            Response.Redirect("ProductAdd.aspx?ID=True&companyid=" + Request.QueryString["companyid"] + "&CategoryId=" + Convert.ToInt32(ddlCategory.SelectedItem.Value) + "&SubCategoryId=" + Convert.ToInt32(ddlSubCategory.SelectedItem.Value) + "&ProductGroupCode=" + Convert.ToInt32(ddlProductGroup.SelectedItem.Value));
    }

    protected void SelectCategories()
    {
        dsCategoryTableAdapters.CategoryTableAdapter taCategory = new dsCategoryTableAdapters.CategoryTableAdapter();
        dsCategory.CategoryDataTable dtCategory;
        int productid=Convert.ToInt32(Request.QueryString["productid"]);


        if ((Request.QueryString["CompanyId"] != null) && (Convert.ToInt16(Request.QueryString["CompanyId"]) != 0))
        {
            int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
            dtCategory = taCategory.SelectCategorybyCompanyId(CompanyId);
            ddlCompany.Items.FindByValue(CompanyId.ToString()).Selected = true;
        }
        else
            dtCategory = taCategory.SelectAllCategory();

        
        ddlCategory.DataSourceID = null;
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataTextField = dtCategory.Columns[1].ToString();
        ddlCategory.DataValueField = dtCategory.Columns[0].ToString();
        ddlCategory.DataBind();

        if ((Request.QueryString["catid"] != null) && (Convert.ToInt16(Request.QueryString["catid"]) != 0))
        {
            ddlCategory.Items.FindByValue(Request.QueryString["catid"]).Selected = true;
            txtTitle.Focus();
        }
        else
            ddlCategory.Items.Insert(0, new ListItem("Please Select", ""));
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProductAdd.aspx?CompanyId=" + ddlCompany.SelectedItem.Value);
    }
}
