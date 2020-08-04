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
    public partial class Message_reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                string getconfig = System.Web.Configuration.WebConfigurationManager.
                    ConnectionStrings[Global.ConnectionString].ConnectionString;

                SqlConnection connection = new SqlConnection(getconfig);

                //要對SQL Server下達的SQL指令，並且將值參數化
                SqlCommand command = new SqlCommand($"SELECT ID, Title, Customer_ID, Content, Message_Date " +
                    $"from Message where (id=@id)", connection);

                command.Parameters.Add("@id", SqlDbType.NVarChar);
                command.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Reply_header.Text = "Re:" + reader["Title"].ToString();
                }
                reader.Close();

                SqlCommand command_1 = new SqlCommand($"select Name from Customer where (ID = @customer_ID)", connection);

                command_1.Parameters.Add("@customer_ID", SqlDbType.NVarChar);
                command_1.Parameters["@customer_ID"].Value = Session["ID"].ToString();
                

                SqlDataReader reader_1 = command_1.ExecuteReader();
                if (reader_1.Read())
                {
                    Reply_name.Text = reader_1["Name"].ToString();
                }
                reader_1.Close();
                connection.Close();
            }

        }

        protected void Press_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Reply_messages.Text) && string.IsNullOrEmpty(Reply_name.Text))
            {
                Message.Text = "請填寫客服人員名稱和內容";
            }
            else if (string.IsNullOrEmpty(Reply_name.Text))
            {
                Message.Text = "請填寫客服人員名稱";
            }
            else if (string.IsNullOrEmpty(Reply_messages.Text))
            {
                Message.Text = "請填寫回覆內容";
            }
            else
            {
                //取得config連結字串資訊
                string getconfig = System.Web.Configuration.WebConfigurationManager.
                    ConnectionStrings[Global.ConnectionString].ConnectionString;

                //建立與資料庫的連結通道，以getconfig內的連結字串連接所對應的資料庫

                SqlConnection connection = new SqlConnection(getconfig);

                //要對SQL Server下達的SQL指令，並且將值參數化
                SqlCommand command = new SqlCommand($"INSERT INTO Reply(Reply_Name, Content, Message_ID)" +
                    $"VALUES(@Name, @content, @id)", connection);

                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = Reply_name.Text;

                command.Parameters.Add("@content", SqlDbType.NVarChar);
                command.Parameters["@content"].Value = Reply_messages.Text;

                command.Parameters.Add("@id", SqlDbType.NVarChar);
                command.Parameters["@id"].Value = Convert.ToInt32(Request.QueryString["id"]);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Response.Redirect("Message_main.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}