using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnBooking
{
    public partial class Room01 : System.Web.UI.Page
    {
        string data;
        protected void Page_Load(object sender, EventArgs e)
        {
            data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Global.ConnectionString].ConnectionString;
            if (Session["Account"] == null)
            {
                Label1.Text = "Guest";
                //logout_b.Visible = false;
            }
            else
            {
                Label1.Text = Convert.ToString(Session["Account"]);
            }
            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            SqlCommand cmd_1 = new SqlCommand();
            cmd_1.Connection = conn;
            cmd_1.CommandText = "Show_Room_Detail";
            cmd_1.CommandType = CommandType.StoredProcedure;
            //宣告參數和給值
            cmd_1.Parameters.Add("@Room_ID", SqlDbType.Int);
            cmd_1.Parameters["@Room_ID"].Value = 1;
            SqlDataReader dr = cmd_1.ExecuteReader();
            while (dr.Read())
            {
                ((Label)FindControl(id: "Type_1")).Text = dr[0].ToString();
                ((Label)FindControl(id: "Price_1")).Text = dr[1].ToString();
                ((Label)FindControl(id: "Detail_1")).Text = dr[2].ToString();
            }
            dr.Close();
        }
    }
}