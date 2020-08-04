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
    public partial class Message_main : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Account"] == null)
                {
                    Response.Redirect("RdLogin.aspx");
                }
                else
                {
                    string id = Request.QueryString["id"];
                    //string Customer_Account = Request.QueryString["Customer_Account"];
                    Image1.Attributes.Add("width", "260");
                    Image1.Attributes.Add("height", "200");

                    string getconfig = System.Web.Configuration.WebConfigurationManager.
                        ConnectionStrings[Global.ConnectionString].ConnectionString;

                    SqlConnection connection = new SqlConnection(getconfig);

                    //要對SQL Server下達的SQL指令，並且將值參數化
                    SqlCommand command = new SqlCommand($"SELECT M.id, Title, Name, Content, Message_Date, Photo " +
                        $"from Message M inner join Customer C on M.Customer_ID = C.ID where (M.id=@id)", connection);

                    command.Parameters.Add("@id", SqlDbType.NVarChar);
                    command.Parameters["@id"].Value = Request["id"];
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Message_header.Text = reader["Title"].ToString();
                        Message_name.Text = reader["Name"].ToString();
                        Message_time.Text = reader["Message_Date"].ToString();
                        Messages.Text = reader["Content"].ToString();

                        byte[] imagem = (byte[])(reader["Photo"]);
                        string PROFILE_PIC = Convert.ToBase64String(imagem);
                        Image1.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
                    }
                    reader.Close();
                    connection.Close();

                    SqlConnection repeat_connection = new SqlConnection(getconfig);

                    //要對SQL Server下達的SQL指令，並且將值參數化
                    SqlCommand repeat_command = new SqlCommand($"SELECT id, Message_ID, Reply_Name, Content, Reply_Date " +
                        $"from Reply where (Message_ID=@id)", repeat_connection);

                    repeat_command.Parameters.Add("@id", SqlDbType.NVarChar);
                    repeat_command.Parameters["@id"].Value = Request.QueryString["id"];
                    repeat_connection.Open();

                    SqlDataReader repeat_reader = repeat_command.ExecuteReader();
                    Repeater1.DataSource = repeat_reader;
                    Repeater1.DataBind();

                }


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_reply.aspx?id=" + Request.QueryString["id"]);
        }

        protected void BacktoMIndex_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_index.aspx");
        }
    }
}