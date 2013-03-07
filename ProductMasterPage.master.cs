using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ProductMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        fill_Tree();
    }

    void fill_Tree()
    {

        SqlConnection SqlCon = new SqlConnection("server=it-asghar;uid=sa;pwd=ltc789*;database=mbc");
        SqlCon.Open();
        SqlCommand SqlCmd = new SqlCommand("SELECT itcatcode,itcatdesc  FROM [Inv_ItemCategory]", SqlCon);
        SqlDataReader Sdr = SqlCmd.ExecuteReader();
        SqlCmd.Dispose();
        string[,] ParentNode = new string[100, 2];
        int count = 0;
        while (Sdr.Read())
        {
            ParentNode[count, 0] = Sdr.GetValue(Sdr.GetOrdinal("itcatcode")).ToString();
            ParentNode[count++, 1] = Sdr.GetValue(Sdr.GetOrdinal("itcatdesc")).ToString();
        }
        Sdr.Close();
        for (int loop = 0; loop < count; loop++)
        {
            TreeNode root = new TreeNode();
            root.Text = ParentNode[loop, 1];
            SqlCommand Module_SqlCmd = new SqlCommand("SELECT itsubcatcode,itscatdesc  FROM [Inv_ItemsubCategory] where itcatcode =" + ParentNode[loop, 0], SqlCon);
            SqlDataReader Module_Sdr = Module_SqlCmd.ExecuteReader();
            while (Module_Sdr.Read())
            {
                TreeNode child = new TreeNode();
                child.Text = Module_Sdr.GetValue(Module_Sdr.GetOrdinal("itscatdesc")).ToString();
                child.Target = "_blank";
                child.NavigateUrl = "#";
                root.ChildNodes.Add(child);
            }
            Module_Sdr.Close();
            TreeView1.Nodes.Add(root);
        }
        TreeView1.CollapseAll();
        SqlCon.Close();

    }
}
