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
    public partial class Message_index : System.Web.UI.Page
    {
        public string customer_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer_ID = Convert.ToString(Session["ID"]);

            if (!IsPostBack)
                bindGridView();


        }

        public void bindGridView()
        {
            if (Session["Account"] == null)
            {
                Label3.Text = "Guest";
                Response.Redirect("RdLogin.aspx");
            }
            else
            {
                Label3.Text = Convert.ToString(Session["Account"]);
                string SQLstring = null;

                //Response.Write(customer_ID);

                string getconfig = System.Web.Configuration.WebConfigurationManager.
                    ConnectionStrings[Global.ConnectionString].ConnectionString;

                SqlConnection connection = new SqlConnection(getconfig);

                if(Session["Account"].ToString().Equals("root"))
                {
                    SQLstring = $"SELECT ID, Title, (select Account from Customer where ID = [Message].Customer_ID) as Customer_Account, Message_Date," +
                    $"(select count(*) from Reply where Message_ID=[Message].id) as 回應 FROM Message ";

                    
                }
                else
                {
                    SQLstring = $"SELECT ID, Title, (select Account from Customer where ID = @customer_ID) as Customer_Account, Message_Date," +
                    $"(select count(*) from Reply where Message_ID=[Message].id) as 回應 FROM Message where Customer_ID = @customer_ID";
                }



                //SqlCommand command = new SqlCommand($"SELECT ID, Title, (select Account from Customer where ID = @customer_ID) as Customer_Account, Message_Date," +
                //    $"(select count(*) from Reply where Message_ID=[Message].id) as 回應 FROM Message where Customer_ID = @customer_ID", connection);

                SqlCommand command = new SqlCommand(SQLstring, connection);

                command.Parameters.Add("@customer_ID", SqlDbType.NVarChar);
                //command.Parameters["@customer_ID"].Value = Request.QueryString["id"];
                command.Parameters["@customer_ID"].Value = Convert.ToInt32(customer_ID);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);



                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                GridView1.DataSource = dataSet;

                GridView1.DataBind();
            }
        }


        protected void logout_b_Click(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("login.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_add.aspx?Customer_ID=" + customer_ID);
        }

        protected void BacktoIndex_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView();
        }
    }
}