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

public partial class admin_BrandsAdd : System.Web.UI.Page
{
   
    connectionstring constring = new connectionstring();
    int Br_Code;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        Br_Code = 0;

        if (Request.QueryString["Br_Code"] != null)
        {
            lblBrands.Text = "Edit Brand";
            Br_Code = Convert.ToInt16(Request.QueryString["Br_Code"]);
            ylibWebClass ylib = new ylibWebClass(constring.connect());
            txtBrandName.Text = ylib.GiveTableQueryValue("select Br_Name from Bas_Brands where Br_Code=" + Br_Code);            
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

        if (Request.QueryString["Br_Code"] == null)
        {
            sqlinsert = "insert into Bas_Brands(Br_Name,inactive) values ('" + txtBrandName.Text + "',0)";
            ylib.ExecuateSQLStatement(sqlinsert);
            Response.Redirect("BrandsAdd.aspx?ID=True");       
        }
        else
        {
            Br_Code=Convert.ToInt16( Request.QueryString["Br_Code"]);
            sqlinsert = "update Bas_Brands set Br_Name='" + txtBrandName.Text + "' where Br_Code=" + Br_Code;
            ylib.ExecuateSQLStatement(sqlinsert);
            Response.Redirect("Brands.aspx");       
        }
        
        
            
        
    }
}
