using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BikeAuthProject
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        [WebMethod]
        public DataSet login(string uname, string pwd)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from [User] where username ='" + uname + "' and password='" + pwd+"'" ,
            @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=bike;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }   
        
        [WebMethod]
        public bool register(string Name, string Address, string username, string MobileNumber, string email, string password,bool rentrequest, string creditcardnumber, string creditcardpassword)
        {
            SqlDataAdapter da = new SqlDataAdapter("insert into [User]"+
                " ( Name,  Address,  username,  MobileNumber,  email, password, rentrequest,  creditcardnumber, creditcardpassword)" +
                "VALUES "+
                 String.Format("( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", Name, Address, username, MobileNumber, email, password, rentrequest, creditcardnumber, creditcardpassword),
            @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=bike;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(da.AcceptChangesDuringFill)
            {
                return true;

            }
            return false;
        }


    }
}
