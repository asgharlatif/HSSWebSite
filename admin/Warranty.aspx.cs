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

public partial class admin_Warranty : System.Web.UI.Page
{
 
    connectionstring constring = new connectionstring();
    ylibWebClass ylib ;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        ylib = new ylibWebClass(constring.connect());


        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Edited";
            }
        }

        BindData();
    }

    private void BindData()
    {
        DataTable DT;
        
        DT= ylib.GiveDataTable_BySQLStatement("SELECT TOP 1000 [WarCode],[WatName],[inactive]  FROM [Bas_Warranties]");

        if (DT.Rows.Count>0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = DT;
            GridView1.DataBind();
        }
        else
        {
            lblMsg.Text = "No record found";
            return;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sqldelet = "";
        if (e.CommandName == "Delete")
        {
            ylib = new ylibWebClass(constring.connect());
            int WarCode = Convert.ToInt32(e.CommandArgument);
            sqldelet = "delete from Bas_Warranties where WarCode=" + WarCode;
            ylib.ExecuateSQLStatement(sqldelet);
            BindData();

        }

        if (e.CommandName == "Edit")
        {
            int WarCode = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("WarrantyAdd.aspx?WarCode=" + WarCode);

        }

       
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");

        }
        
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}