using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnBooking
{
    public partial class Message_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] == null)
            {
                //Label1.Text = "Guest";
                Response.Redirect("RdLogin.aspx");
            }
            else
            {
                //Label1.Text = Convert.ToString(Session["Account"]);

                string getconfig = System.Web.Configuration.WebConfigurationManager.
                ConnectionStrings[Global.ConnectionString].ConnectionString;

                SqlConnection connection = new SqlConnection(getconfig);

                //要對SQL Server下達的SQL指令，並且將值參數化
                SqlCommand command = new SqlCommand($"select Account from Customer where (ID = @customer_ID)", connection);

                command.Parameters.Add("@customer_ID", SqlDbType.NVarChar);
                command.Parameters["@customer_ID"].Value = Convert.ToInt32(Request.QueryString["customer_ID"]);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TextBox2.Text = reader["Account"].ToString();
                }
                connection.Close();

            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            byte[] title = Encoding.Default.GetBytes(TextBox1.Text);
            byte[] content = Encoding.Default.GetBytes(TextBox3.Text);
            byte[] fileData = FileUpload1.FileBytes;
            if (title.Length >= 100)
            {
                Warm.Text = "留言標題請輸入少於 100 字元";
            }
            else if (content.Length >= 100)
            {
                Warm.Text = "留言內容請輸入少於 100 字元";
            }
            else
            {
                //取得config連結字串資訊
                string getconfig = System.Web.Configuration.WebConfigurationManager.
                    ConnectionStrings[Global.ConnectionString].ConnectionString;

                //建立與資料庫的連結通道，以getconfig內的連結字串連接所對應的資料庫

                SqlConnection connection = new SqlConnection(getconfig);

                //要對SQL Server下達的SQL指令，並且將值參數化
                SqlCommand command = new SqlCommand($"INSERT INTO Message(Title, Customer_ID, Content, Message_Date, Photo) " +
                    $"VALUES(@title, @customerID, @Content, CONVERT(datetime,SWITCHOFFSET ( SYSDATETIMEOFFSET(), '+08:00')), @Photo)", connection);

                //賦予參數資料型態與值
                command.Parameters.Add("@title", SqlDbType.NVarChar);
                command.Parameters["@title"].Value = TextBox1.Text;

                command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                command.Parameters["@customerID"].Value = Convert.ToInt32(Request.QueryString["Customer_ID"]);

                command.Parameters.Add("@Content", SqlDbType.NVarChar);
                command.Parameters["@Content"].Value = TextBox3.Text;

                command.Parameters.Add("@Photo", SqlDbType.Binary);
                command.Parameters["@Photo"].Value = fileData;

                //string sql = "EXEC [Reservation].[dbo].[Ins_Message] '" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "','" + TextBox3.Text.ToString() + "'";
                //SqlCommand command = new SqlCommand(sql, connection);//要對SQL Server下什麼SQL指令。

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Response.Redirect("Message_index.aspx?Customer_ID=" + Request.QueryString["customer_ID"]);
            }
        }


    }
}