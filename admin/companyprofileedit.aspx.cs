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

public partial class admin_companyprofileedit : System.Web.UI.Page
{
    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

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


        if (Request.QueryString["companyid"] != null)
        {
            int companyid = Convert.ToInt32(Request.QueryString["companyid"]);
            dtCompany = taCompany.SelectAllCompanyByCompanyId(companyid);

            if (dtCompany.Rows.Count > 0)
            {
                    DataRow row = dtCompany.Rows[0];
                    lblCompany.Text = row["CompanyName"].ToString();
                    txtAboutCompany.Text = row["AboutCompany"].ToString();
                    txtBrand.Text = row["Brand"].ToString();
                    txtOwner.Text = row["Owner"].ToString();
                    txtYearEstablished.Text = row["YearEstablished"].ToString();
                    txtContact.Text = row["Contact"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtTel1.Text = row["Tel1"].ToString();
                    txtFax1.Text = row["Fax1"].ToString();
                    txtURL.Text = row["URL"].ToString();
                    txtZipCode.Text = row["ZipCode"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    txtBusinessType.Text = row["BusinessType"].ToString();
                    txtMainProduct.Text = row["MainProduct"].ToString();
                    txtMainMarket.Text = row["MainMarket"].ToString();
                    txtApprovalCertificate.Text = row["ApprovalCertificate"].ToString();
                    txtMembership.Text = row["Membership"].ToString();
                    lblLogoName.Text = row["logoName"].ToString();
                    Image1.ImageUrl = "~/thumbnail.aspx?Image=Images/Logo/" + row["logoName"].ToString() ;  

            }
           
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int CompanyId = Convert.ToInt32(Request.QueryString["CompanyId"]);

        string fileName1="";

        if (FileUpload1.HasFile)
        {
            fileName1 = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(Request.ApplicationPath) + "\\Images\\Logo\\" + FileUpload1.FileName);
        }
        else
            fileName1 = lblLogoName.Text;


        taCompany.UpdateProfile(txtAboutCompany.Text.Trim(), txtBrand.Text.Trim(), txtOwner.Text.Trim(), txtYearEstablished.Text.Trim(), txtContact.Text.Trim(),
        txtEmail.Text.Trim(), txtTel1.Text.Trim(), txtFax1.Text.Trim(), txtURL.Text.Trim(), txtZipCode.Text.Trim(), txtAddress.Text.Trim(),
        txtBusinessType.Text.Trim(), txtMainProduct.Text.Trim(), txtMainMarket.Text.Trim(), txtApprovalCertificate.Text.Trim(), txtMembership.Text,fileName1,
        CompanyId);

        Response.Redirect("companies.aspx?ID=True&CompanyId=" + CompanyId);
    }
}