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

public partial class admin_CustomerAdd : System.Web.UI.Page
{
    dsCustomersTableAdapters.CustomersTableAdapter taCustomers = new dsCustomersTableAdapters.CustomersTableAdapter();
    dsCustomers.CustomersDataTable dtCustomers;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Added";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dtCustomers = taCustomers.SelectCutomerbyEmail(txtEmail.Text.Trim());

        if (dtCustomers.Rows.Count > 0)
        {
            lblMsg.Text = "User with provided email address already exists";
            return;
        }

        taCustomers.AddCustomer(txtName.Text.Trim(),
                                txtEmail.Text.Trim(),
                                txtAddress.Text.Trim(),
                                txtCity.Text.Trim(),
                                Convert.ToBoolean(rblNewsLetter.SelectedItem.Value),
                                txtPassword.Text.Trim(),
                                DateTime.Now,
                                true);

        Response.Redirect("CustomerAdd.aspx?ID=True");
    }
}
