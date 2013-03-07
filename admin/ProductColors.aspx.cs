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

public partial class admin_ProductColors : System.Web.UI.Page
{
    dsProductColorsTableAdapters.ProductColorsImagesTableAdapter taProductColors = new dsProductColorsTableAdapters.ProductColorsImagesTableAdapter();
    dsProductColors.ProductColorsImagesDataTable dtProductColors; 
    
    dsProductTableAdapters.ProductTableAdapter taProduct = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProduct;

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
        if (Request.QueryString["ProductId"] != null)
        {
            int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
            dtProduct = taProduct.SelectProductNamebyProductId(Convert.ToInt32(Request.QueryString["ProductId"]));
            
            if (dtProduct.Rows.Count > 0)
            {
                lblProductTitle.Text = "against " + dtProduct[0].ProductTitle.ToString();
            }
            else
            {
                btnAdd.Visible = false;
                lblMsg.Text = "No record found.";
                return;
            }

            dtProductColors = taProductColors.SelectProductColorsByProductId(productId);
            

            if (dtProductColors.Rows.Count > 0)
            {
                GridView1.DataSource = dtProductColors;
                GridView1.DataBind();
            }
            else
            {
                GridView1.Visible = false;
                lblMsg.Text = "No record found.";
            }
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
            int productColorId = Convert.ToInt32(e.CommandArgument);
            taProductColors.DeleteProductColors(productColorId);
            BindData();
        }

        if (e.CommandName == "EditItem")
        {
            int productColorId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ProductColorEdit.aspx?ProductColorId=" + productColorId);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDel = (LinkButton)e.Row.FindControl("delbutton");
            btnDel.Attributes.Add("OnClick", "return confirm('Are you sure to delete this record?');");

            Label lblColorId = (Label)e.Row.FindControl("lblColorId");
            Label lblProductId = (Label)e.Row.FindControl("lblProductId");

            dtProduct = taProduct.SelectProductNamebyProductId(Convert.ToInt32(lblProductId.Text));
            if (dtProduct.Rows.Count > 0)
            {
                lblProductId.Text = dtProduct[0].ProductTitle.ToString();
            }
            dtColors = taColors.SelectColorTitlebyColorId(Convert.ToInt32(lblColorId.Text));
            if (dtColors.Rows.Count > 0)
                lblColorId.Text = dtColors[0].ColorTitle.ToString();

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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductColorAdd.aspx?ProductId=" + Request.QueryString["ProductId"]);
    }
}
