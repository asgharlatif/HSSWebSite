using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ProductSimilarSet : System.Web.UI.Page
{
    SimilarSetTableAdapters.ProductSimilarSetTableAdapter taSimilarSet = new SimilarSetTableAdapters.ProductSimilarSetTableAdapter();
    SimilarSet.ProductSimilarSetDataTable dtSimilarSet;
    
     dsCompanyTableAdapters.CompanyTableAdapter taCompany = new dsCompanyTableAdapters.CompanyTableAdapter();
    dsCompany.CompanyDataTable dtCompany;

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
        dtSimilarSet = taSimilarSet.GetData();

        if (dtSimilarSet.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = dtSimilarSet;
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
            int SetCode = Convert.ToInt32(e.CommandArgument);
            taSimilarSet.DeleteQuery(SetCode);
            BindData();

        }

        if (e.CommandName == "Edit")
        {
            int SetCode = Convert.ToInt32(e.CommandArgument);
            int CompanyId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("SimilarSetEdit.aspx?SetCode=" + SetCode );

        }


        if (e.CommandName == "ManageProducts")
        {
            int SetCode = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ProductSimilarSetDetail.aspx?SetCode=" + SetCode);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");

            Label lblCompanyId = (Label)e.Row.FindControl("lblCompanyId");
            if (lblCompanyId.Text != "")
            {
                dtCompany = taCompany.SelectCompanyNameFromCompanyId(Convert.ToInt32(lblCompanyId.Text));

                if (dtCompany.Rows.Count > 0)
                    lblCompanyId.Text = dtCompany[0].CompanyName.ToString();
                else
                    lblCompanyId.Visible = false;
            }
        }
    }

    
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}