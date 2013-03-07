using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ClassP;

public partial class admin_DocumentsDetails : System.Web.UI.Page
{
    connectionstring constr = new connectionstring();
    ylibWebClass ylib;
    int DocumenType = 0;
    int osDocumenType = 0;
    dsProductDocumentationTableAdapters.ProductDocumentationTableAdapter taProductDocumentation = new dsProductDocumentationTableAdapters.ProductDocumentationTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        ylib = new ylibWebClass(constr.connect());
        
        BindData();

    }
    private void BindData()
    {   

        lblProductId.Text =Request.QueryString["ProductId"].ToString();
        DocumenType = Convert.ToInt16(Request.QueryString["DocumenType"].ToString());
        osDocumenType = Convert.ToInt16(Request.QueryString["osDocumenType"].ToString());

        if (DocumenType == 0)
            lblDocumentype.Text = "Documents ";
        else if (DocumenType == 1)
            lblDocumentype.Text = "Drivers ";

        DataTable DT1;
        DT1 = ylib.GiveDataTable_BySQLStatement("SELECT  OSId,osdescription,[DocumentId],[DocumentName],LanguageId,LanguageName FROM [HSS].[dbo].[v_DocumentsLanguages] where DocumenType=" + DocumenType + " and osDocumenType=" + osDocumenType + " order by DocumentId");

        if (DT1.Rows.Count > 0)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = DT1;
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

        if (e.CommandName == "Add")
        {
            string[] Str = new string[3];

            Str=e.CommandArgument.ToString().Split('?');

            Int16 DocumentId = Convert.ToInt16(Str[0].ToString());
            Int16 LanguageId = Convert.ToInt16(Str[1].ToString());
            Int16 OSId= Convert.ToInt16(Str[2].ToString());

            Response.Redirect("uploadbrochures.aspx?DocumentId=" + DocumentId + "&ProductId=" + Convert.ToInt16(Request.QueryString["ProductId"].ToString()) + "&LanguageId=" + LanguageId + "&DocumenType=" + Request.QueryString["DocumenType"].ToString() + "&osDocumenType=" + Request.QueryString["osDocumenType"].ToString() + "&OSId=" + OSId);
        }
        else if (e.CommandName == "Delete")
        {
            string[] Str = new string[3];

            Str = e.CommandArgument.ToString().Split('?');

            Int16 DocumentId = Convert.ToInt16(Str[0].ToString());
            Int16 LanguageId = Convert.ToInt16(Str[1].ToString());
            Int16 OSId = Convert.ToInt16(Str[2].ToString());

            taProductDocumentation.DeleteQuery(Convert.ToInt16(Request.QueryString["ProductId"]), DocumentId, LanguageId, OSId);

            Response.Redirect("DocumentsDetails.aspx?ProductId=" + Request.QueryString["ProductId"] + "&DocumenType=" + Request.QueryString["DocumenType"].ToString() + "&osDocumenType=" + Request.QueryString["osDocumenType"].ToString());

        }
        else if (e.CommandName == "Download")
        {
            ylib = new ylibWebClass(constr.connect());
            string FileExtension = "";

            DataTable DT1;
            string pdfurl = "";

            string[] Str = new string[3];

            Str = e.CommandArgument.ToString().Split('?');

            Int16 DocumentId = Convert.ToInt16(Str[0].ToString());
            Int16 LanguageId = Convert.ToInt16(Str[1].ToString());
            Int16 OSId = Convert.ToInt16(Str[2].ToString());

            DT1 = ylib.GiveDataTable_BySQLStatement("SELECT top 1 [ProductId],[LanguageId],[DocumentId],[DocumentDescription],ThumbNailName_,UploadedFileName  FROM [ProductDocumentation] where ProductId=" + Request.QueryString["ProductId"] + " and DocumentId=" + DocumentId + " and LanguageId = " + LanguageId + " and OSId=" + OSId);

            if (DT1.Rows.Count > 0)
            {
                FileExtension=System.IO.Path.GetExtension(DT1.Rows[0]["UploadedFileName"].ToString());
                pdfurl = "../Documentation/" + DocumentId + "-" + LanguageId + "-" + OSId + "-"  + Request.QueryString["ProductId"] + System.IO.Path.GetExtension(DT1.Rows[0]["UploadedFileName"].ToString()); 
            }

            Response.Clear();
            Response.ContentType = "application/x-pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=TechnicalFile" + FileExtension);
            Response.TransmitFile(pdfurl);
            Response.End();

        }


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable DT1;
        Int64 ProductId = 0;
        int LanguageId;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ProductId = Convert.ToInt64(Request.QueryString["ProductId"].ToString());


            Label lblDocumentId = (Label)e.Row.FindControl("lblDocumentId");
            Label lblLanguageId = (Label)e.Row.FindControl("lblLanguageId");
            Label lblOSId = (Label)e.Row.FindControl("lblOSId");


            LinkButton btnAdd = (LinkButton)e.Row.FindControl("btnAdd");
            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            LinkButton btnDownload = (LinkButton)e.Row.FindControl("btnDownload");

            
            Image Image1 = (Image)e.Row.FindControl("Image1");



            LanguageId =Convert.ToInt16( lblLanguageId.Text);

            DT1 = ylib.GiveDataTable_BySQLStatement("SELECT  [ProductId],[LanguageId],[DocumentId],[DocumentDescription],ThumbNailName_,UploadedFileName,OSId  FROM [HSS].[dbo].[ProductDocumentation] where ProductId='" + ProductId + "' and DocumentId=" + Convert.ToInt16(lblDocumentId.Text) + " and LanguageId = " + Convert.ToInt16(lblLanguageId.Text) + " and OSId=" + Convert.ToInt16(lblOSId.Text));

            if (DT1.Rows.Count > 0)
            {

                Image1.ImageUrl = "../Documentation/DocumentationThumbNail/" + lblDocumentId.Text + "-" + lblLanguageId.Text + "-" + lblOSId.Text + "-" + ProductId.ToString() + System.IO.Path.GetExtension(DT1.Rows[0]["ThumbNailName_"].ToString());
                    btnDownload.CssClass = System.IO.Path.GetExtension(DT1.Rows[0]["UploadedFileName"].ToString()).Replace(".", "").ToString();

                    btnAdd.Visible = false;
            }
            else
            {               
                   lbtnDelete.Visible = false;
                   btnDownload.Visible = false;
            }



        }
    }

}