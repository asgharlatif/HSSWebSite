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

public partial class admin_Companies : System.Web.UI.Page
{
    FillWebControlClass FCF = new FillWebControlClass();

    connectionstring constr = new connectionstring();
    ylibWebClass ylib;

    dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

    dsAdminTableAdapters.AdminTableAdapter taAdmin = new dsAdminTableAdapters.AdminTableAdapter();
    dsAdmin.AdminDataTable dtAdmin;

    

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

        BindData();
    }

    private void BindData()
    {
        dtCompany = taCompany.SelectAllCompany();
        if (dtCompany.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtCompany;
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
        if (e.CommandName == "Delete")
        {
            int CompanyId = Convert.ToInt32(e.CommandArgument);
            taCompany.DeleteCompany(CompanyId);
            BindData();

        }

        if (e.CommandName == "Edit")
        {
            int CompanyId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("companyedit.aspx?CompanyId=" + CompanyId);

        }

        if (e.CommandName == "Profile")
        {
           
            int CompanyId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("companyprofileedit.aspx?CompanyId=" + CompanyId);
        }

        if (e.CommandName == "Products")
        {
            int CompanyId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ManageCompanyProducts.aspx?CompanyId=" + CompanyId);
            
        }

        if (e.CommandName == "Group")
        {
            int CompanyId = Convert.ToInt32(e.CommandArgument);            
            taCompany.MarkCurrentCompanyAsGroup(CompanyId);
            BindData();

        }

        if (e.CommandName == "GroupProfile")
        {
            int CompanyId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("EditGroupProfile.aspx?CompanyId=" + CompanyId);

        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");
       

        LinkButton lbtnSetAsGroup = (LinkButton)e.Row.FindControl("lbtnSetAsGroup");

        if (lbtnSetAsGroup.Text == "True")
            lbtnSetAsGroup.Text = "Group of Company";
        else
            lbtnSetAsGroup.Text =  "Mark as Group of Company";
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        lblCompanyId.Text = gvrow.Cells[0].Text;
        FillBaseFiles(Convert.ToInt16(lblCompanyId.Text));

        this.ModalPopupExtender1.Show();
    }

    private void FillBaseFiles(int CompanyId)
    {
        DataTable DT1;
        ylib = new ylibWebClass(constr.connect());

        dtAdmin = taAdmin.GetAllUsers();
        FCF.FillCheckBoxList(ref loclst, dtAdmin, "LoginId", "AdminId");
        DT1 = ylib.GiveDataTable_BySQLStatement("select adminid from Admin_Company_Transaction where companyid=" + CompanyId);
        FCF.SelectItemInCheckBoxList2(ref loclst, DT1, "AdminId", "Int32");
    }

    protected void btnUpdateList_Click(object sender, EventArgs e)
    {
        Int16 itemindex = 0;
        DBSetting.DatabaseOperation dbo = new DBSetting.DatabaseOperation(constr.connect());

        #region locationlist
       

        itemindex = 0;
        foreach (ListItem listItem in loclst.Items)
        {
            if (listItem.Selected == true)
            {
                ArrayList ReportFormulaNames = new ArrayList { "AdminId", "CompanyId", "@itemindex" };
                ArrayList ReportFormulaValues = new ArrayList { listItem.Value.ToString(), Convert.ToInt16(lblCompanyId.Text), itemindex };
                dbo.InsertBySPStringArr("prc_ins_Admin_Company_Transaction", ref ReportFormulaNames, ref ReportFormulaValues);
                itemindex = Convert.ToInt16(itemindex + 1);
            }
        }

        #endregion

    }
}