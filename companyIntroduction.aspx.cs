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

public partial class companyIntroduction : System.Web.UI.Page
{

    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsFeedBackTableAdapters.FeedbackTableAdapter taFeedBack = new dsFeedBackTableAdapters.FeedbackTableAdapter();
    dsFeedBack.FeedbackDataTable dtFeedBack;



    protected void Page_Load(object sender, EventArgs e)
    {

        SelectLogo();
        SetHotSaleItems();
        SetFeaturedItems();
        SetHeaderLabels();
        SetProfileDetail();
    }

    private void SetProfileDetail()
    {
        if (Request.QueryString["companyid"] != null)
        {
            int companyid = Convert.ToInt32(Request.QueryString["companyid"]);
            dtCompany = taCompany.SelectAllCompanyByCompanyId(companyid);

            if (dtCompany.Rows.Count > 0)
            {

                DataRow row = dtCompany.Rows[0];
                
                lblAboutCompany.Text = row["AboutCompany"].ToString();
                lblBrand.Text = row["Brand"].ToString();
                lblOwner.Text = row["Owner"].ToString();
                lblYearEstablished.Text = row["YearEstablished"].ToString();
                lblContact.Text = row["Contact"].ToString();
                lblEmail.Text = row["Email"].ToString();
                lblTel1.Text = row["Tel1"].ToString();
                lblFax1.Text = row["Fax1"].ToString();
                lblURL.Text = row["URL"].ToString();
                lblZipCode.Text = row["ZipCode"].ToString();
                lblAddress.Text = row["Address"].ToString();
                lblBusinessType.Text = row["BusinessType"].ToString();
                lblMainProduct.Text = row["MainProduct"].ToString();
                lblMainMarket.Text = row["MainMarket"].ToString();
                lblApprovalCertificate.Text = row["ApprovalCertificate"].ToString();
                lblMembership.Text = row["Membership"].ToString();
            }

        }
    }

    private void SetHotSaleItems()
    {
        dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();      
        DataList1.DataSource = taProduct.GetHotSale(Convert.ToInt16(Request.QueryString["CompanyId"]), true, false);
        DataList1.DataBind();
    }

    private void SetFeaturedItems()
    {
        dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
        DataList2.DataSource = taProduct.GetFeaturedProducts(Convert.ToInt16(Request.QueryString["CompanyId"]), false, true);
        DataList2.DataBind();
    }

    private void SelectLogo()
    {
        switch (Request.QueryString["qv"].ToString())
        {
            case "mb":
                Image3.ImageUrl = "~/frontimages/SmallPics/MBCom_Logo.gif";
                //lblcompname.Text = "MB COMMUNICATIONS";

                //lblBrand.Text = "Black Copper"; 
                //lblEmail.Text="najeeb@mbcommunication.com.pk";
                //lnkUrl.Text = "http://mbcommunication.com.pk/";
                //lblBusinessType.Text = "Networking Products";
                //lblMainProducts.Text = "Switches and Routers";
                //lblCertificate.Text = "Black Copper";
                //lblMembership.Text="Taiwan Association of Networking Products ";
               
                break;
            case "bc":
                Image3.ImageUrl = "~/frontimages/SmallPics/BlackCopper_Logo.gif";
                //lblcompname.Text = "BLACK COPPERS";

                //lblBrand.Text = "Black Copper";
                //lblEmail.Text="najeeb@blackcopper.com.pk";
                //lnkUrl.Text = "http://blackcopper.net/";
                //lblBusinessType.Text = "Networking Accessories";
                //lblMainProducts.Text = "Labtops";
                //lblCertificate.Text = "Black Copper";
                //lblMembership.Text="Taiwan Association of Networking Products ";

                break;
            case "bs":
                Image3.ImageUrl = "~/frontimages/SmallPics/BadiShop_Logo.gif";
                //lblcompname.Text = "BADI SHOPS";

                //lblBrand.Text = "Export Quality";
                //lblEmail.Text="najeeb@badishops.com.pk";
                //lnkUrl.Text = "http://badishops.com.pk/";
                //lblBusinessType.Text = "General Accessories";
                //lblMainProducts.Text = "Agricutlures and Food Items";
                //lblCertificate.Text = "Fresh Food Association of Pakistan";
                //lblMembership.Text="Pakistan Association of Fresh Foods and Agriculures";

                break;
            case "bb":
                Image3.ImageUrl = "~/frontimages/SmallPics/BikenBike_Logo.gif";
                //lblcompname.Text = "BIKE AND BIKE";

                //lblBrand.Text = "DYL (Yamaha) , Honda";
                //lblEmail.Text="najeeb@bikenbike.com.pk";
                //lnkUrl.Text = "http://bikenbike.com.pk/";
                //lblBusinessType.Text = "Motorcycles and Spare Parts";
                //lblMainProducts.Text = "DYL Motorcycles , Honda , Suzuky and Chineese bikes";
                //lblCertificate.Text = "DYL Motorcycles Pvt Ltd";
                //lblMembership.Text = "Pakistan Automotive Manufacturers Association";
                break;
            case "wa":
                Image3.ImageUrl = "~/frontimages/SmallPics/WebArt_Logo.gif";
                //lblcompname.Text = "WEB ART";

                //lblBrand.Text = "Microsoft";
                //lblEmail.Text="najeeb@webart.com.pk";
                //lnkUrl.Text = "http://webart.com.pk/";
                //lblBusinessType.Text = "Logo and Website Designing";
                //lblMainProducts.Text = ".Net Web Development using C# , Adobe Photoshop CS11 and .Net Desktop Application Development ";
                //lblCertificate.Text = "Microsoft";
                //lblMembership.Text = "Microsoft Certified Professional";

                break;
    
        }
        
    }

    private void SetHeaderLabels()
    {
        switch (Request.QueryString["qv"])
        {
            case "bs":
                lblaboutthecompany.Text = "About Badi Shops";
                lblCompanyProfile.Text = "Badi Shops profile detail";
                lblHotSale.Text = "Hot Sale of Badi Shops";
                lblFeaturedProducts.Text = "Featured Products of Badi shops";
                lblInquiretocompany.Text = "Make Inquiry to Badi Shops";
                lblMapLocation.Text = "Map Location of Badi Shops";
                break;
            case "bc":
                lblaboutthecompany.Text = "About Black Copper";
                lblCompanyProfile.Text = "Black Copper profile detail";
                lblHotSale.Text = "Hot Sale of Black Copper";
                lblFeaturedProducts.Text = "Featured Products of Black Copper";
                lblInquiretocompany.Text = "Make Inquiry to Black Copper";
                lblMapLocation.Text = "Map Location of Black Copper";

                break;
            case "wa":
                lblaboutthecompany.Text = "About Web Art";
                lblCompanyProfile.Text = "Web Art profile detail";
                lblHotSale.Text = "Hot Sale of Web Art";
                lblFeaturedProducts.Text = "Featured Products of Web Art";
                lblInquiretocompany.Text = "Make Inquiry to Web Art";
                lblMapLocation.Text = "Map Location of Web Art";
                break;
            case "mb":
                lblaboutthecompany.Text = "About MB Communication";
                lblCompanyProfile.Text = "MB profile detail";
                lblHotSale.Text = "Hot Sale of MB";
                lblFeaturedProducts.Text = "Featured Products of MB";
                lblInquiretocompany.Text = "Make Inquiry to MB";
                lblMapLocation.Text = "Map Location of MB";

                break;
            case "bb":
                lblaboutthecompany.Text = "About BikenBike";
                lblCompanyProfile.Text = "BikenBike profile detail";
                lblHotSale.Text = "Hot Sale of BikenBike";
                lblFeaturedProducts.Text = "Featured Products of BikenBike";
                lblInquiretocompany.Text = "Make Inquiry to BikenBike";
                lblMapLocation.Text = "Map Location of BikenBike";

                break;

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int companyid = Convert.ToInt32(Request.QueryString["companyid"]);

        taFeedBack.AddFeedBack(txtName.Text.Trim(),
                             txtEmail1.Text.Trim(),
                             txtPhone.Text.Trim(),
                             txtCity.Text.Trim(),
                             txtOccupation.Text.Trim(),
                             txtCompany.Text.Trim(),
                             ddlAge.SelectedItem.Value,
                             txtComments1.Text.Trim(),
                             DateTime.Now);

        Server.Transfer("EmailTemplates/FeedbackEmailConfirmation.aspx?companyid=" + companyid);
    }

    #region Properties Section
    
    public string Name
    {
        get { return txtName.Text.Trim(); }
    }
    public string Email
    {
        get { return txtEmail1.Text.Trim(); }
    }
    public string Phone
    {
        get { return txtPhone.Text.Trim(); }
    }
    public string City
    {
        get { return txtCity.Text.Trim(); }
    }
    public string Occupation
    {
        get { return txtOccupation.Text.Trim(); }
    }
    public string Company
    {
        get { return txtCompany.Text.Trim(); }
    }
    public string Age
    {
        get { return ddlAge.SelectedItem.Text; }
    }
    public string Comments
    {
        get { return txtComments1.Text.Trim(); }
    }
    #endregion
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
