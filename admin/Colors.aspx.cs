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

public partial class admin_Colors : System.Web.UI.Page
{
    dsColorsTableAdapters.ColorsTableAdapter taColors = new dsColorsTableAdapters.ColorsTableAdapter();
    dsColors.ColorsDataTable dtColors;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Edited";
            }
        } 

        BindData();
    }
    private void BindData()
    {
        dtColors = taColors.SelectAllColors();
        if (dtColors.Rows.Count > 0)
        {
            GridView1.DataSource = dtColors;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            lblMsg.Text = "No record found";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int colorId = Convert.ToInt32(e.CommandArgument);
            taColors.DeleteColor(colorId);
            BindData();
        }

        if (e.CommandName == "EditItem")
        {
            int colorId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ColorEdit.aspx?ColorId=" + colorId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDel = (LinkButton)e.Row.FindControl("delbutton");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        BindData();
        DataTable p_DataTable = GridView1.DataSource as DataTable;

        if (p_DataTable != null)
        {
            int p_PageIndex = GridView1.PageIndex;

            string p_SortDirection = GetSortDirection();

            DataView p_DataView = new DataView(p_DataTable);
            p_DataView.Sort = e.SortExpression + " " + p_SortDirection;

            GridView1.DataSource = p_DataView;
            GridView1.DataBind();
            GridView1.PageIndex = p_PageIndex;
        }
    }

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string GetSortDirection()
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }

        return GridViewSortDirection;
    }
}
