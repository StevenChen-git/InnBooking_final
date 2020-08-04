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
    public partial class RQuery_check : System.Web.UI.Page
    {
        string data;
        string sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] == null)
            {
                //Session["ID"] = 4;
                Label1.Text = "Guest";
                Response.Redirect("RdLogin.aspx");
                //logout_b.Visible = false;
            }
            else
            {
                Label1.Text = Convert.ToString(Session["Account"]);
            }
            Session["Enter"] = 'N';//User還沒按確認建
            data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Global.ConnectionString].ConnectionString;//從config找到資料庫位置[]內放的是Web.config的connectionStrings的name
            Session["Order_ID"] = null;
        }
        protected void logout_b_Click(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("login.aspx");
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["Order_ID"] = RadioButtonList1.SelectedValue;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Count"] = "Y";
            //開啟連線
            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            // 查看有效訂單總價
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Query_Member_Order";
            cmd.CommandType = CommandType.StoredProcedure;
            //宣告參數和給值
            cmd.Parameters.Add("@Customer_ID", SqlDbType.Int);
            cmd.Parameters["@Customer_ID"].Value = Session["ID"];
            cmd.Parameters.Add("@Count", SqlDbType.NVarChar);
            cmd.Parameters["@Count"].Value = Session["Count"];
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Count"] = "N";
            //開啟連線
            SqlConnection conn = new SqlConnection(data);
            conn.Open();
            // 查看明細
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Query_Member_Order";
            cmd.CommandType = CommandType.StoredProcedure;
            //宣告參數和給值
            cmd.Parameters.Add("@Customer_ID", SqlDbType.Int);
            cmd.Parameters["@Customer_ID"].Value = Session["ID"];
            cmd.Parameters.Add("@Count", SqlDbType.NVarChar);
            cmd.Parameters["@Count"].Value = Session["Count"];
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            conn.Close();

        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            //開啟連線
            SqlConnection conn = new SqlConnection(data);

            if (Session["Order_ID"] == null)
            {
                Session["Order_ID"] = 0;
                conn.Open();
                //  可刪除訂單選項
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Del_Order";
                cmd.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd.Parameters.Add("@Customer_ID", SqlDbType.Int);
                cmd.Parameters["@Customer_ID"].Value = Session["ID"];
                cmd.Parameters.Add("@Order_ID", SqlDbType.Int);
                cmd.Parameters["@Order_ID"].Value = Session["Order_ID"];
                SqlDataReader dr = cmd.ExecuteReader();
                RadioButtonList1.DataSource = dr;
                RadioButtonList1.DataTextField = "可以刪除的訂單編號";
                RadioButtonList1.DataBind();
                dr.Close();
                conn.Close();
            }

            /*           else
                       {
                           conn.Open();
                           //  刪除訂單
                           SqlCommand cmd = new SqlCommand();
                           cmd.Connection = conn;
                           cmd.CommandText = "Del_Order";
                           cmd.CommandType = CommandType.StoredProcedure;
                           //宣告參數和給值
                           cmd.Parameters.Add("@Customer_ID", SqlDbType.Int);
                           cmd.Parameters["@Customer_ID"].Value = Session["ID"];
                           cmd.Parameters.Add("@Order_ID", SqlDbType.Int);
                           cmd.Parameters["@Order_ID"].Value = Session["Order_ID"];
                           cmd.ExecuteNonQuery();
                           // 確認刪除狀況
                           SqlCommand cmd_1 = new SqlCommand();
                           cmd_1.Connection = conn;
                           cmd_1.CommandText = "Check_Del_Order";
                           cmd_1.CommandType = CommandType.StoredProcedure;
                           //宣告參數和給值
                           cmd_1.Parameters.Add("@Customer_ID", SqlDbType.Int);
                           cmd_1.Parameters["@Customer_ID"].Value = Session["ID"];
                           cmd_1.Parameters.Add("@Order_ID", SqlDbType.Int);
                           cmd_1.Parameters["@Order_ID"].Value = Session["Order_ID"];
                           SqlDataReader dr_1 = cmd_1.ExecuteReader();
                           GridView2.DataSource = dr_1;
                           GridView2.DataBind();
                           dr_1.Close();
                           conn.Close();
                       }
                       */
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(data);
            if (Session["Order_ID"] != null)
            {
                conn.Open();
                //  刪除訂單
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Del_Order";
                cmd.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd.Parameters.Add("@Customer_ID", SqlDbType.Int);
                cmd.Parameters["@Customer_ID"].Value = Session["ID"];
                cmd.Parameters.Add("@Order_ID", SqlDbType.Int);
                cmd.Parameters["@Order_ID"].Value = Session["Order_ID"];
                cmd.ExecuteNonQuery();
                // 確認刪除狀況
                SqlCommand cmd_1 = new SqlCommand();
                cmd_1.Connection = conn;
                cmd_1.CommandText = "Check_Del_Order";
                cmd_1.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_1.Parameters.Add("@Customer_ID", SqlDbType.Int);
                cmd_1.Parameters["@Customer_ID"].Value = Session["ID"];
                cmd_1.Parameters.Add("@Order_ID", SqlDbType.Int);
                cmd_1.Parameters["@Order_ID"].Value = Session["Order_ID"];
                SqlDataReader dr_1 = cmd_1.ExecuteReader();
                GridView2.DataSource = dr_1;
                GridView2.DataBind();
                dr_1.Close();


                Session["Count"] = "N";

                // 查看明細
                SqlCommand cmd_new = new SqlCommand();
                cmd_new.Connection = conn;
                cmd_new.CommandText = "Query_Member_Order";
                cmd_new.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_new.Parameters.Add("@Customer_ID", SqlDbType.Int);
                cmd_new.Parameters["@Customer_ID"].Value = Session["ID"];
                cmd_new.Parameters.Add("@Count", SqlDbType.NVarChar);
                cmd_new.Parameters["@Count"].Value = Session["Count"];
                SqlDataReader dr_new = cmd_new.ExecuteReader();
                GridView1.DataSource = dr_new;
                GridView1.DataBind();
                dr_new.Close();

                Session["Order_ID"] = 0;
                SqlCommand cmd_radio = new SqlCommand();
                cmd_radio.Connection = conn;
                cmd_radio.CommandText = "Del_Order";
                cmd_radio.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_radio.Parameters.Add("@Customer_ID", SqlDbType.Int);
                cmd_radio.Parameters["@Customer_ID"].Value = Session["ID"];
                cmd_radio.Parameters.Add("@Order_ID", SqlDbType.Int);
                cmd_radio.Parameters["@Order_ID"].Value = Session["Order_ID"];
                SqlDataReader dr_radio = cmd_radio.ExecuteReader();
                RadioButtonList1.DataSource = dr_radio;
                RadioButtonList1.DataTextField = "可以刪除的訂單編號";
                RadioButtonList1.DataBind();
                dr_radio.Close();
                conn.Close();

            }
            Session["Order_ID"] = null;
        }
    }
}