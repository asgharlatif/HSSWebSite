using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegProcess : System.Web.UI.Page
{
    
    dsCustomersTableAdapters.CustomersTableAdapter taCustomer = new dsCustomersTableAdapters.CustomersTableAdapter();
    dsCustomers.CustomersDataTable dtCustomer;

    string ReqForm ;
    string Email ;
    string Password ;
    string Name ;
    string City ;
    string Address ;
    string Subscribed  ;
    string URL  ;

    protected void Page_Load(object sender, EventArgs e)
    {

        string ReqForm = Request.Form.Get("ReqForm");
        string Email = Request.Form.Get("Email");
        string Password = Request.Form.Get("Password");
        string Name = Request.Form.Get("Name");
        string City = Request.Form.Get("City");
        string Address = Request.Form.Get("Address");
        Boolean Subscribed =Convert.ToBoolean( Request.Form.Get("Subscribed"));
        string URL = Request.Form.Get("URL");

        switch (ReqForm)
        {
            case "SignUp":

                if (Convert.ToInt16(taCustomer.IfEmailExists(Email)) == 0)
                {
                    taCustomer.AddCustomer(Name, Email, Address, City, Subscribed, Password, DateTime.Now, false);
                    TextBox1.Text = "Success";
                }
                else
                {
                    TextBox1.Text = "P";
                }
                
         
                break;

            case "LogIn":

                if (Convert.ToInt16(taCustomer.IfEmailExists(Email)) == 0)
                {
                    Session["CustomerLogin"] = false;
                    Session["email"] = null;

                    TextBox1.Text = "InvalidEmail";
                }
                if (Convert.ToInt16(taCustomer.IfValidUserIdPwd(Email,Password)) == 0)
                {

                    Session["CustomerLogin"] = false;
                    Session["email"] = null;
                    TextBox1.Text = "InvalidPwd";      
                }
                else
                {
                    Session["CustomerLogin"] = true;
                    Session["email"] = Email;
                    TextBox1.Text = "Success";
              
                }


                break; 

            default:
                TextBox1.Text = "UndefinedAction";
                break;
        }

        
    }

   
}