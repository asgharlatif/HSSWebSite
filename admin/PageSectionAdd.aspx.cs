using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassP;

public partial class PageSectionAdd : System.Web.UI.Page
{

    dsMainPageSectionTableAdapters.MainPageSectionTableAdapter taMainPageSection = new dsMainPageSectionTableAdapters.MainPageSectionTableAdapter();
    dsMainPageSection.MainPageSectionDataTable dtMainPageSection;

    int SectionCode;
    
    connectionstring concls = new connectionstring();
    ClassP.ylibWebClass ylib;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        SectionCode = 0;
        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Successfully Added";
            }
        }

        LoadCompanies();

        if (Request.QueryString["SectionCode"] != null)
        {
            SectionCode = Convert.ToInt16(Request.QueryString["SectionCode"]);

            ylib = new ClassP.ylibWebClass(concls.connect());

            ddlPagePartName.Items.FindByValue(ylib.GiveTableQueryValue("select pagepartname from MainPageSection where SectionCode=" + SectionCode)).Selected = true;
            ddlCompany.Items.FindByValue(ylib.GiveTableQueryValue("select CompanyId from MainPageSection where SectionCode=" + SectionCode)).Selected = true;
            
            txtSectionName.Text = ylib.GiveTableQueryValue("select SectionName from MainPageSection where SectionCode=" + SectionCode);
            txtSortingOrder.Text = ylib.GiveTableQueryValue("select SortingOrder from MainPageSection where SectionCode=" + SectionCode);

            
            lblFormLabel.Text = "Edit Product Group";
            btnAdd.Text = "Edit";
        }

    }

    protected void LoadCompanies()
    {
        
        connectionstring concls = new connectionstring();
        ylibWebClass ylib = new ylibWebClass(concls.connect());
        FillWebControlClass FCC = new FillWebControlClass();
       
        FCC.FillDropDownList(ref ddlPagePartName, ylib.GiveDataTable_BySQLStatement("select PagePartName,PagePartName from PageParts"), "PagePartName", "PagePartName", true, false,"");
        FCC.FillDropDownList(ref ddlCompany, ylib.GiveDataTable_BySQLStatement("select CompanyId,CompanyName from Company"), "CompanyName", "CompanyId", true, false, "");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["SectionCode"] !=null)
        SectionCode = Convert.ToInt16(Request.QueryString["SectionCode"]);

        taMainPageSection.Prc_Ins_MainPageSection(SectionCode,Convert.ToInt32(ddlCompany.SelectedItem.Value), ddlPagePartName.SelectedItem.Value, txtSectionName.Text, Convert.ToInt32(txtSortingOrder.Text), DateTime.Now);
        if (SectionCode == 0)            
            Response.Redirect("PageSectionAdd.aspx?ID=True");
        else
            Response.Redirect("MainPageSection.aspx");
        

    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}