using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassP;

public partial class admin_MainPageSection : System.Web.UI.Page
{
    dsMainPageSectionTableAdapters.MainPageSectionTableAdapter taMainPageSection = new dsMainPageSectionTableAdapters.MainPageSectionTableAdapter();
    dsMainPageSection.MainPageSectionDataTable dtMainPageSection;

    connectionstring concls = new connectionstring();
    ClassP.ylibWebClass ylib;

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

        LoadCompanies();
    }
    protected void LoadCompanies()
    {

        connectionstring concls = new connectionstring();
        ylibWebClass ylib = new ylibWebClass(concls.connect());
        FillWebControlClass FCC = new FillWebControlClass();

        
        FCC.FillDropDownList(ref ddlCompany, ylib.GiveDataTable_BySQLStatement("select CompanyId,CompanyName from Company"), "CompanyName", "CompanyId", true, false, "");
    }
    private void BindData()
    {
        dtMainPageSection = taMainPageSection.GetDataByCompanyId(Convert.ToInt16( ddlCompany.SelectedValue.ToString()));
        
        if (dtMainPageSection.Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtMainPageSection;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "No record found";
            return;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int SectionCode = Convert.ToInt32(e.CommandArgument);
            taMainPageSection.Delete(SectionCode);
            BindData();

        }

        if (e.CommandName == "Edit")
        {
            int SectionCode = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("PageSectionAdd.aspx?SectionCode=" + SectionCode);

        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");


            //LinkButton lbtnSetAsGroup = (LinkButton)e.Row.FindControl("lbtnSetAsGroup");

            //if (lbtnSetAsGroup.Text == "True")
            //    lbtnSetAsGroup.Text = "Group of Company";
            //else
            //    lbtnSetAsGroup.Text = "Mark as Group of Company";
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}