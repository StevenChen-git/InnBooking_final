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
    public partial class RQuery_Room : System.Web.UI.Page
    {
        string data;
        string sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Global.ConnectionString].ConnectionString;//從config找到資料庫位置[]內放的是Web.config的connectionStrings的name
            Session["Sort"] = 'A';
            if (Session["Account"] == null)
            {
                Label6.Text = "Guest";
                Response.Redirect("RdLogin.aspx");
            }
            else
            {
                Label6.Text = Convert.ToString(Session["Account"]);
            }
        }



        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Session["Start_Date"] = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged1(object sender, EventArgs e)
        {
            Session["End_Date"] = Calendar2.SelectedDate.ToShortDateString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Start_Date"] == null)
            {
                Label5.Text = ("請選擇訂房日期");
            }
            else if (Session["End_Date"] == null)
            {
                Label5.Text = ("請選擇退房日期");
            }
            else
            {
                Session["Sort"] = 'A';
                //開啟連線
                SqlConnection conn = new SqlConnection(data);
                conn.Open();
                // 查詢可用的房型
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Query_Room";
                cmd.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd.Parameters.Add("@Sort", SqlDbType.NVarChar);
                cmd.Parameters["@Sort"].Value = Session["Sort"];
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                // 房型選項
                SqlCommand cmd_1 = new SqlCommand();
                cmd_1.Connection = conn;
                cmd_1.CommandText = "Query_Room_List";
                cmd_1.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_1.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd_1.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd_1.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd_1.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd_1.Parameters.Add("@Count", SqlDbType.NVarChar);
                cmd_1.Parameters["@Count"].Value = "N";
                SqlDataReader dr_1 = cmd_1.ExecuteReader();
                RadioButtonList1.DataSource = dr_1;
                RadioButtonList1.DataTextField = "Type";
                RadioButtonList1.DataBind();
                dr_1.Close();

                SqlCommand cmd_2 = new SqlCommand();
                cmd_2.Connection = conn;
                cmd_2.CommandText = "Query_Room_List";
                cmd_2.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_2.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd_2.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd_2.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd_2.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd_2.Parameters.Add("@Count", SqlDbType.NVarChar);
                cmd_2.Parameters["@Count"].Value = "Y";
                SqlDataReader dr_2 = cmd_2.ExecuteReader();
                while (dr_2.Read())
                {
                    Session["Num"] = (int)dr_2[0];
                    Label5.Text = "查詢結果：總共有 " + Session["Num"].ToString() + "間房間可以預訂";
                }
                dr_2.Close();


                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["Start_Date"] == null)
            {
                Label5.Text = ("請選擇訂房日期");
            }
            else if (Session["End_Date"] == null)
            {
                Label5.Text = ("請選擇退房日期");
            }
            else
            {
                Session["Sort"] = 'D';
                //開啟連線
                SqlConnection conn = new SqlConnection(data);
                conn.Open();
                // 查詢可用的房型
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Query_Room";
                cmd.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd.Parameters.Add("@Sort", SqlDbType.NVarChar);
                cmd.Parameters["@Sort"].Value = Session["Sort"];
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                // 房型選項
                SqlCommand cmd_1 = new SqlCommand();
                cmd_1.Connection = conn;
                cmd_1.CommandText = "Query_Room_List";
                cmd_1.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_1.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd_1.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd_1.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd_1.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd_1.Parameters.Add("@Count", SqlDbType.NVarChar);
                cmd_1.Parameters["@Count"].Value = "N";
                SqlDataReader dr_1 = cmd_1.ExecuteReader();
                RadioButtonList1.DataSource = dr_1;
                RadioButtonList1.DataTextField = "Type";
                RadioButtonList1.DataBind();
                dr_1.Close();

                SqlCommand cmd_2 = new SqlCommand();
                cmd_2.Connection = conn;
                cmd_2.CommandText = "Query_Room_List";
                cmd_2.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_2.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd_2.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd_2.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd_2.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd_2.Parameters.Add("@Count", SqlDbType.NVarChar);
                cmd_2.Parameters["@Count"].Value = "Y";
                SqlDataReader dr_2 = cmd_2.ExecuteReader();
                while (dr_2.Read())
                {
                    Session["Num"] = (int)dr_2[0];
                    Label5.Text = "查詢結果：總共有 " + Session["Num"].ToString() + "間房間可以預訂";
                }
                dr_2.Close();

                conn.Close();
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["Room_Type"] = RadioButtonList1.SelectedValue;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["Start_Date"] == null)
            {
                Label5.Text = ("請選擇訂房日期");
            }
            else if (Session["End_Date"] == null)
            {
                Label5.Text = ("請選擇退房日期");
            }
            else if (Session["Room_Type"] == null)
            {
                Label5.Text = ("請選擇預定房型");
            }
            else if (Convert.ToDateTime(Session["Start_Date"]) >= Convert.ToDateTime(Session["End_Date"]))
            {

            }
            else
            {
                Response.Redirect("Check_Room.aspx");
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (Session["Start_Date"] != null && Session["End_Date"] != null && Session["Room_Type"] != null)
            {
                SqlConnection conn = new SqlConnection(data);
                conn.Open();
                // 查詢可用的房型
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Query_Room";
                cmd.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd.Parameters.Add("@Sort", SqlDbType.NVarChar);
                cmd.Parameters["@Sort"].Value = Session["Sort"];
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();

                // 房型選項
                SqlCommand cmd_1 = new SqlCommand();
                cmd_1.Connection = conn;
                cmd_1.CommandText = "Query_Room_List";
                cmd_1.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_1.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd_1.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd_1.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd_1.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd_1.Parameters.Add("@Count", SqlDbType.NVarChar);
                cmd_1.Parameters["@Count"].Value = "N";
                SqlDataReader dr_1 = cmd_1.ExecuteReader();
                RadioButtonList1.DataSource = dr_1;
                RadioButtonList1.DataTextField = "Type";
                RadioButtonList1.DataBind();
                dr_1.Close();


                SqlCommand cmd_3 = new SqlCommand();
                cmd_3.Connection = conn;
                cmd_3.CommandText = "Query_Room_List";
                cmd_3.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_3.Parameters.Add("@Start_Date", SqlDbType.DateTime);
                cmd_3.Parameters["@Start_Date"].Value = Session["Start_Date"];
                cmd_3.Parameters.Add("@End_Date", SqlDbType.DateTime);
                cmd_3.Parameters["@End_Date"].Value = Session["End_Date"];
                cmd_3.Parameters.Add("@Count", SqlDbType.NVarChar);
                cmd_3.Parameters["@Count"].Value = "Y";
                SqlDataReader dr_3 = cmd_3.ExecuteReader();
                while (dr_3.Read())
                {
                    Session["Num_new"] = (int)dr_3[0];
                }
                dr_3.Close();

                if ((int)Session["Num"] != (int)Session["Num_new"])
                {
                    Label5.Text = "查詢結果已更動：原有" + Session["Num"].ToString() + "間房間，現在剩下 " + Session["Num_new"].ToString() + "間房間可以預訂";
                    //string script = "alert(\"已有其他人在相同時間下訂單了，請盡快選擇 or 重新查詢\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(),
                    //                      "ServerControlScript", script, true);
                }

                conn.Close();
            }

        }


    }
}