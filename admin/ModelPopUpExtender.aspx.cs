using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassP;
using System.Data;

public partial class admin_ModelPopUpExtender : System.Web.UI.Page
{
    connectionstring constr = new connectionstring();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataTable DT;
            ylibWebClass ylib = new ylibWebClass(constr.connect());
            DT = ylib.GiveDataTable_BySQLStatement("select AuthorId,name,points from auther");
            if (DT.Rows.Count > 0)
            {
                gdvauthors.DataSource = DT;
                gdvauthors.DataBind();
            }
        }
    }




    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        lblID.Text = gvrow.Cells[0].Text;
        txtname.Text = gvrow.Cells[1].Text;
        txtpoints.Text = gvrow.Cells[2].Text;
        this.ModalPopupExtender1.Show();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Update the record here
        this.ModalPopupExtender1.Hide();
        //imgbtn_Click
    }
}