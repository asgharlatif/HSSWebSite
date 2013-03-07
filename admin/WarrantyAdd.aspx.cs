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

public partial class admin_WarrantyAdd : System.Web.UI.Page
{
   
    connectionstring constring = new connectionstring();
    int WarCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        WarCode = 0;

        if (Request.QueryString["WarCode"] != null)
        {
            lblWarranty.Text = "Edit Warranty";
            WarCode = Convert.ToInt16(Request.QueryString["WarCode"]);
            ylibWebClass ylib = new ylibWebClass(constring.connect());
            txtWatName.Text = ylib.GiveTableQueryValue("select WatName from Bas_Warranties where WarCode=" + WarCode);            
        }


        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Added";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        string sqlinsert = "";
        ylibWebClass ylib = new ylibWebClass(constring.connect());

        if (Request.QueryString["WarCode"] == null)
        {
            sqlinsert = "insert into Bas_Warranties(WatName,inactive) values ('" + txtWatName.Text + "',0)";
            ylib.ExecuateSQLStatement(sqlinsert);
            Response.Redirect("WarrantyAdd.aspx?ID=True");       
        }
        else
        {
            WarCode=Convert.ToInt16( Request.QueryString["WarCode"]);
            sqlinsert = "update Bas_Warranties set WatName='" + txtWatName.Text + "' where WarCode=" + WarCode;
            ylib.ExecuateSQLStatement(sqlinsert);
            Response.Redirect("Warranty.aspx");       
        }
        
        
            
        
    }
}
