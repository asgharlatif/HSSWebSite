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

public partial class MasterPage : System.Web.UI.MasterPage
{
    dsProductTableAdapters.ProductTableAdapter taProducts = new dsProductTableAdapters.ProductTableAdapter();
    dsProduct.ProductDataTable dtProducts;
    dsCategoryTableAdapters.CategoryTableAdapter taCategories = new dsCategoryTableAdapters.CategoryTableAdapter();
    dsCategory.CategoryDataTable dtCategories;
    dsNewsLetterGroupsTableAdapters.GroupsTableAdapter taNewsLetterGroup = new dsNewsLetterGroupsTableAdapters.GroupsTableAdapter();
    dsNewsLetterGroups.GroupsDataTable dtNewsLetterGroup;
    dsSubscribersTableAdapters.SubscribersTableAdapter taSubscriber = new dsSubscribersTableAdapters.SubscribersTableAdapter();
    dsSubscribers.SubscribersDataTable dtSubscriber;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Title.ToString() == "DYL Motorcycles - Welcome")
            breadcrumb.Visible = false;

        dtCategories = taCategories.SelectAllCategory();
        Repeater1.DataSource = dtCategories;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        Label lblCategoryId = (Label)e.Item.FindControl("lblCategoryId");

        Repeater Repeater2 = (Repeater)e.Item.FindControl("Repeater2");        
        dtProducts = taProducts.SelectProductbyCategoryId(Convert.ToInt32(lblCategoryId.Text));        
        Repeater2.DataSource = dtProducts;        
        Repeater2.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //dtNewsLetterGroup = taNewsLetterGroup.SelectFromGroupWhereTitleIsNone();
        //if(dtNewsLetterGroup.Rows.Count > 0)
        //{
        //    taSubscriber.AddSubscriber(Convert.ToInt32(dtNewsLetterGroup[0].GroupId.ToString()),
        //                               txtSearch.Text.Trim(),
        //                               DateTime.Now);

        //}
        Response.Redirect("Subscriber-Add.aspx?Subscriber=" + txtSearch.Text.Trim());
    }
}
