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

public partial class admin_CustomerEdit : System.Web.UI.Page
{
    dsCustomersTableAdapters.CustomersTableAdapter taCustomers = new dsCustomersTableAdapters.CustomersTableAdapter();
    dsCustomers.CustomersDataTable dtCustomers;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
}
