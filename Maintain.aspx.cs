using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnBooking
{
    public partial class Maintain : System.Web.UI.Page
    {
		string data;
		protected void Page_Load(object sender, EventArgs e)
		{
			data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Global.ConnectionString].ConnectionString;
			if (Session["Account"] == null)
			{
				user.Text = "Guest";
				//Response.Redirect("RdLogin.aspx");
				//logout_b.Visible = false;
			}
			else
			{
				user.Text = Convert.ToString(Session["Account"]);
				
			}
		}
		protected void logout_b_Click(object sender, EventArgs e)
		{
			Session["Account"] = null;
			Response.Redirect("login.aspx");
		}

		// 確認新增
		protected void Button1_Click(object sender, EventArgs e)
		{
			byte[] fileData = FileUpload1.FileBytes;
			SqlConnection conn = new SqlConnection(data);
			if (Session["Bathroom_new"] == null)
			{
				Session["Bathroom_new"] = "0";
			}
			if (Session["Bathtub_new"] == null)
			{
				Session["Bathtub_new"] = "0";
			}
			if (Session["Hair_Dryer_new"] == null)
			{
				Session["Hair_Dryer_new"] = "0";
			}
			if (Session["Refrigerator_new"] == null)
			{
				Session["Refrigerator_new"] = "0";
			}
			if (Session["Toiletries_new"] == null)
			{
				Session["Toiletries_new"] = "0";
			}
			if (Session["KTV_new"] == null)
			{
				Session["KTV_new"] = "0";
			}
			if (Session["Security_Box_new"] == null)
			{
				Session["Security_Box_new"] = "0";
			}
			if (Session["Swimming_Pool_new"] == null)
			{
				Session["Swimming_Pool_new"] = "0";
			}
			// null判斷
			if (TextBox1.Text == null)
			{
				Label15.Text = "請輸入設定房型";
			}
			else if (TextBox2.Text == null)
			{
				Label15.Text = "請輸入設定房型價錢";
			}
			else if (FileUpload1.HasFile == false)
			{
				Label15.Text = "選擇房型圖片";
			}  
			// 格式判斷
			else if (Price_Check(TextBox2.Text) == false)
			{
				Label15.Text = "價格格式錯誤,請輸入有兩位小數的正實數";
			}
			else
			{
				conn.Open();
				// 新增
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = "Ins_Room_Detail";
				cmd.CommandType = CommandType.StoredProcedure;
				//宣告參數和給值
				cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
				cmd.Parameters["@Type"].Value = TextBox1.Text;
				cmd.Parameters.Add("@Photo", SqlDbType.Binary);
				cmd.Parameters["@Photo"].Value = fileData;
				cmd.Parameters.Add("@Price", SqlDbType.Decimal);
				cmd.Parameters["@Price"].Value = Decimal.Parse(TextBox2.Text);
				cmd.Parameters.Add("@Bathroom", SqlDbType.NVarChar);
				cmd.Parameters["@Bathroom"].Value = Session["Bathroom_new"];
				cmd.Parameters.Add("@Bathtub", SqlDbType.NVarChar);
				cmd.Parameters["@Bathtub"].Value = Session["Bathtub_new"];
				cmd.Parameters.Add("@Hair_Dryer", SqlDbType.NVarChar);
				cmd.Parameters["@Hair_Dryer"].Value = Session["Hair_Dryer_new"];
				cmd.Parameters.Add("@Refrigerator", SqlDbType.NVarChar);
				cmd.Parameters["@Refrigerator"].Value = Session["Refrigerator_new"];
				cmd.Parameters.Add("@Toiletries", SqlDbType.NVarChar);
				cmd.Parameters["@Toiletries"].Value = Session["Toiletries_new"];
				cmd.Parameters.Add("@KTV", SqlDbType.NVarChar);
				cmd.Parameters["@KTV"].Value = Session["KTV_new"];
				cmd.Parameters.Add("@Security_Box", SqlDbType.NVarChar);
				cmd.Parameters["@Security_Box"].Value = Session["Security_Box_new"];
				cmd.Parameters.Add("@Swimming_Pool", SqlDbType.NVarChar);
				cmd.Parameters["@Swimming_Pool"].Value = Session["Swimming_Pool_new"];
				cmd.ExecuteNonQuery();
				conn.Close();
				Label15.Text = null;
			}

		}

		//new
		protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			Session["Bathroom_new"] = CheckBox1.Checked ? '1' : '0';
		}

		protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			Session["Bathtub_new"] = CheckBox2.Checked ? '1' : '0';
		}

		protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			Session["Hair_Dryer_new"] = CheckBox3.Checked ? '1' : '0';
		}

		protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
		{
			Session["Refrigerator_new"] = CheckBox4.Checked ? '1' : '0';
		}

		protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
		{
			Session["Toiletries_new"] = CheckBox5.Checked ? '1' : '0';
		}

		protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
		{
			Session["KTV_new"] = CheckBox6.Checked ? '1' : '0';
		}

		protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
		{
			Session["Security_Box_new"] = CheckBox7.Checked ? '1' : '0';
		}

		protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
		{
			Session["Swimming_Pool_new"] = CheckBox8.Checked ? '1' : '0';
		}



		// 更新房型
		protected void Button3_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(data);
			SqlCommand cmd_room = new SqlCommand($"select type from Room", conn);
			conn.Open();
			SqlDataReader dr_room = cmd_room.ExecuteReader();
			DropDownList1.DataSource = dr_room;
			DropDownList1.DataTextField = "type";
			DropDownList1.DataBind();
			dr_room.Close();
			conn.Close();
		}
		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session["Update_Room"] = DropDownList1.SelectedValue;
		}

		//價格驗證
		public bool Price_Check(string Price)
		{
			// 使用「正規表達式」檢驗格式  只能輸入有兩位小數的正實數
			bool flag = Regex.IsMatch(Price, @"^[0-9]+(.[0-9]{2})?$");
			return flag;
		}
		// 確認更新
		protected void Button2_Click(object sender, EventArgs e)
		{
			byte[] fileData = FileUpload2.FileBytes;
			SqlConnection conn = new SqlConnection(data);
			if (Session["Bathroom_upd"] == null)
			{
				Session["Bathroom_upd"] = "0";
			}
			if (Session["Bathtub_upd"] == null)
			{
				Session["Bathtub_upd"] = "0";
			}
			if (Session["Hair_Dryer_upd"] == null)
			{
				Session["Hair_Dryer_upd"] = "0";
			}
			if (Session["Refrigerator_upd"] == null)
			{
				Session["Refrigerator_upd"] = "0";
			}
			if (Session["Toiletries_upd"] == null)
			{
				Session["Toiletries_upd"] = "0";
			}
			if (Session["KTV_upd"] == null)
			{
				Session["KTV_upd"] = "0";
			}
			if (Session["Security_Box_upd"] == null)
			{
				Session["Security_Box_upd"] = "0";
			}
			if (Session["Swimming_Pool_upd"] == null)
			{
				Session["Swimming_Pool_upd"] = "0";
			}
			// null判斷
			if (Session["Update_Room"] == null)
			{
				Label16.Text = "請輸入更新房型";
			}
			else if (TextBox4.Text == null)
			{
				Label16.Text = "請輸入更新房型價錢";
			}
			// 格式判斷
			else if (Price_Check(TextBox4.Text) == false)
			{
				Label16.Text = "價格格式錯誤,請輸入有兩位小數的正實數";
			}
			else
			{
				conn.Open();
				// 新增
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = "Update_Room_Detail";
				cmd.CommandType = CommandType.StoredProcedure;
				//宣告參數和給值
				cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
				cmd.Parameters["@Type"].Value = Session["Update_Room"];
				cmd.Parameters.Add("@Photo", SqlDbType.Binary);
				cmd.Parameters["@Photo"].Value = fileData;
				cmd.Parameters.Add("@Price", SqlDbType.Decimal);
				cmd.Parameters["@Price"].Value = decimal.Parse(TextBox4.Text);
				cmd.Parameters.Add("@Bathroom", SqlDbType.NVarChar);
				cmd.Parameters["@Bathroom"].Value = Session["Bathroom_upd"];
				cmd.Parameters.Add("@Bathtub", SqlDbType.NVarChar);
				cmd.Parameters["@Bathtub"].Value = Session["Bathtub_upd"];
				cmd.Parameters.Add("@Hair_Dryer", SqlDbType.NVarChar);
				cmd.Parameters["@Hair_Dryer"].Value = Session["Hair_Dryer_upd"];
				cmd.Parameters.Add("@Refrigerator", SqlDbType.NVarChar);
				cmd.Parameters["@Refrigerator"].Value = Session["Refrigerator_upd"];
				cmd.Parameters.Add("@Toiletries", SqlDbType.NVarChar);
				cmd.Parameters["@Toiletries"].Value = Session["Toiletries_upd"];
				cmd.Parameters.Add("@KTV", SqlDbType.NVarChar);
				cmd.Parameters["@KTV"].Value = Session["KTV_upd"];
				cmd.Parameters.Add("@Security_Box", SqlDbType.NVarChar);
				cmd.Parameters["@Security_Box"].Value = Session["Security_Box_upd"];
				cmd.Parameters.Add("@Swimming_Pool", SqlDbType.NVarChar);
				cmd.Parameters["@Swimming_Pool"].Value = Session["Swimming_Pool_upd"];
				cmd.ExecuteNonQuery();
				conn.Close();
				Label16.Text = null;
			}
		}

		//upd
		protected void CheckBox9_CheckedChanged(object sender, EventArgs e)
		{
			Session["Bathroom_upd"] = CheckBox9.Checked ? '1' : '0';
		}

		protected void CheckBox10_CheckedChanged(object sender, EventArgs e)
		{
			Session["Bathtub_upd"] = CheckBox10.Checked ? '1' : '0';
		}

		protected void CheckBox11_CheckedChanged(object sender, EventArgs e)
		{
			Session["Hair_Dryer_upd"] = CheckBox11.Checked ? '1' : '0';
		}

		protected void CheckBox12_CheckedChanged(object sender, EventArgs e)
		{
			Session["Refrigerator_upd"] = CheckBox12.Checked ? '1' : '0';
		}

		protected void CheckBox13_CheckedChanged(object sender, EventArgs e)
		{
			Session["Toiletries_upd"] = CheckBox13.Checked ? '1' : '0';
		}

		protected void CheckBox14_CheckedChanged(object sender, EventArgs e)
		{
			Session["KTV_upd"] = CheckBox14.Checked ? '1' : '0';
		}

		protected void CheckBox15_CheckedChanged(object sender, EventArgs e)
		{
			Session["Security_Box_upd"] = CheckBox15.Checked ? '1' : '0';
		}

		protected void CheckBox16_CheckedChanged(object sender, EventArgs e)
		{
			Session["Swimming_Pool_upd"] = CheckBox16.Checked ? '1' : '0';
		}
		// 刪除房型
		protected void Button4_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(data);
			SqlCommand cmd_room = new SqlCommand($"select type from Room", conn);
			conn.Open();
			SqlDataReader dr_room = cmd_room.ExecuteReader();
			DropDownList2.DataSource = dr_room;
			DropDownList2.DataTextField = "type";
			DropDownList2.DataBind();
			dr_room.Close();
			conn.Close();
		}
		// 刪除
		protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session["Delete_Room"] = DropDownList2.SelectedValue;
		}
		// 確認刪除
		protected void Button5_Click(object sender, EventArgs e)
		{
			if (Session["Delete_Room"] == null)
			{
				Label21.Text = "請選擇要刪除的房型";
			}
			else
			{
				
				SqlConnection conn = new SqlConnection(data);
				conn.Open();
				// 新增
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = "Del_Room_Detail";
				cmd.CommandType = CommandType.StoredProcedure;
				//宣告參數和給值
				cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
				cmd.Parameters["@Type"].Value = Session["Delete_Room"];
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		
		}

	}
}