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




public partial class EmailTemplates_FeedbackEmailConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["companyid"] != null)
        {
            
            companyIntroduction FB;
            FB = (companyIntroduction)Context.Handler;           

            ImgCompLogo.ImageUrl = "frontimages/logo/11.gif";
           
            //frontimages / compinfofeatureditems /

            lblName2.Text = FB.Name;
            lblName.Text = FB.Name;
            lblEmail.Text = FB.Email;
            lblPhone.Text = FB.Phone;
            lblCity.Text = FB.City;
            lblOccupation.Text = FB.Occupation;
            lblCompany.Text = FB.Company;
            lblAge.Text = FB.Age;
            lblComments.Text = FB.Comments;
        }
        else
        {
            //"~/frontimages/SmallPics/MBCom_Logo.gif";
            ImgCompLogo.ImageUrl = "frontimages/logo/SmallLogo.gif";

            inquireaboutus FB;
            FB = (inquireaboutus)Context.Handler;
            lblName2.Text = FB.Name;
            lblName.Text = FB.Name;
            lblEmail.Text = FB.Email;
            lblPhone.Text = FB.Phone;
            lblCity.Text = FB.City;
            lblOccupation.Text = FB.Occupation;
            lblCompany.Text = FB.Company;
            lblAge.Text = FB.Age;
            lblComments.Text = FB.Comments;
        }


        string sIPAddress;
        sIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if ((sIPAddress == "") || (sIPAddress == null))
            sIPAddress = Request.ServerVariables["REMOTE_ADDR"];            

        lblIPAddress.Text = sIPAddress;

        setCompAddress();
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
        message.To.Add(lblEmail.Text);
        message.Bcc.Add(System.Web.Configuration.WebConfigurationManager.AppSettings["ConfirmationEmail1"]);



        message.Subject = "User Queries / Inquiries to " + GlobalFromName;
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
