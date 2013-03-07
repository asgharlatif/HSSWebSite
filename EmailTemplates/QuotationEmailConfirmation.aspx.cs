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
using System.Net.Mail;
using System.Text;
using System.IO;

public partial class EmailTemplates_QuotationEmailConfirmation : System.Web.UI.Page
{
    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string visitorid = Session["NewGuid"].ToString();

        dtProduct = taProduct.SelectProductbyVisitorId(visitorid);

        if (dtProduct.Rows.Count > 0)
        {
            Repeater1.DataSource = dtProduct;
            Repeater1.DataBind();
            setCompAddress();
        }
    }   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
    }

    private void setCompAddress()
    {
        dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
        dsCompany.CompanyDataTable dtCompany;

        if (Request.QueryString["companyid"] == null)
        {
            lblAddress.Text = System.Web.Configuration.WebConfigurationManager.AppSettings["GlobalAddress0"];
        }
        else
        {
            int companyid = Convert.ToInt32(Request.QueryString["companyid"]);
            dtCompany = taCompany.SelectAllCompanyByCompanyId(companyid);

            if (dtCompany.Rows.Count > 0)
            {
                DataRow row = dtCompany.Rows[0];
                lblAddress.Text = row["Address"].ToString();
            }

        }
    }

    protected override void Render(HtmlTextWriter writer)
    {

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        Html32TextWriter htw = new Html32TextWriter(sw);
        string GlobalFromName = "";

        emailme.RenderControl(htw);

        string body = sb.ToString();

        MailMessage message = new MailMessage();

        if (Request.QueryString["companyid"] != null)
            GlobalFromName = System.Web.Configuration.WebConfigurationManager.AppSettings["GlobalFromName" + Request.QueryString["companyid"]];
        else
            GlobalFromName = System.Web.Configuration.WebConfigurationManager.AppSettings["GlobalFromName0"];


        message.From = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["GlobalFromEmail"], GlobalFromName);
        message.To.Add("asghar@dawood-companies.com");
        message.Bcc.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["ConfirmationEmail1"]);



        message.Subject = "Quotation being recieved from  " + GlobalFromName;
        message.Body = body;
        message.BodyEncoding = Encoding.ASCII;
        message.IsBodyHtml = true;
        System.Net.NetworkCredential mailAuthentication = new
        System.Net.NetworkCredential(System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPUser"], System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPPassword"]);

        System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(System.Web.Configuration.WebConfigurationManager.AppSettings["SMTP"]);

        //Enable SSL
        mailClient.EnableSsl = Convert.ToBoolean(System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSecure"]);
        mailClient.UseDefaultCredentials = false;
        mailClient.Credentials = mailAuthentication;
        mailClient.Send(message);

        Response.Redirect("Thankyou.aspx?ID=Feedback");


    }

}