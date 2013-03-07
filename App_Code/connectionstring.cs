using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
/// <summary>
/// Summary description for connectionstring
/// </summary>
public class connectionstring
{
    public connectionstring()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string connect()
    {
        //return ("Data Source=[devcom\webserver];Initial Catalog=HSS;User ID=sa;Password=ctldyl");
        //return ("Data Source=it-asghar;Initial Catalog=HSS;User ID=sa;Password=ltc789*");

        return (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MBCConnectionString"].ToString());
    }
    
    public string GetUniqGuid()
    {
        return Guid.NewGuid().ToString().GetHashCode().ToString("x");
    }
    public string GetUniqueKey()
    {
        int maxSize = 8;

        char[] chars = new char[62];
        string a;
        a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        chars = a.ToCharArray();
        int size = maxSize;
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        size = maxSize;
        data = new byte[size];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(size);
        foreach (byte b in data)
        {
            result.Append(chars);
        }
        return result.ToString();
    }
}
