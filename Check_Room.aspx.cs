using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnBooking
{
    public partial class Check_Room : System.Web.UI.Page
    {
		string data;
		string sql;
		string CreditCard_Number;
		string Security_Code;
		string Name_On_CreditCard;
		DateTime date1;
		SqlConnection conn;
		int Num; //紀錄同一個客戶訂單數目
		int Num_New; //紀錄同一個客戶訂單數目
		protected void Page_Load(object sender, EventArgs e)
		{
			data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Global.ConnectionString].ConnectionString;
			SqlConnection conn = new SqlConnection(data);
			SqlCommand cmd_mail = new SqlCommand($"select Email from Customer where ID=@ID", conn);
			//宣告參數和給值
			cmd_mail.Parameters.Add("@ID", SqlDbType.Int);
			cmd_mail.Parameters["@ID"].Value = Session["ID"]; ;
			conn.Open();
			SqlDataReader dr_mail = cmd_mail.ExecuteReader();
			while (dr_mail.Read())
			{
				Session["Email"] = dr_mail[0].ToString();
			}
			dr_mail.Close();


			//找 同一個客戶 訂單有幾筆資料
			SqlCommand cmd_order = new SqlCommand($"select count(*) from [Order] where Customer_ID=@ID", conn);
			//宣告參數和給值
			cmd_order.Parameters.Add("@ID", SqlDbType.Int);
			cmd_order.Parameters["@ID"].Value = Session["ID"];
			SqlDataReader dr_order = cmd_order.ExecuteReader();
			while (dr_order.Read())
			{
				Num = (int)dr_order[0];
			}
			dr_order.Close();
			conn.Close();


			if (Session["Account"] == null)
			{
				Label13.Text = "Guest";
				Response.Redirect("RdLogin.aspx");
			}
			else
			{
				Label13.Text = Convert.ToString(Session["Account"]);
				Label8.Text = Session["Start_Date"].ToString();
				Label9.Text = Session["End_Date"].ToString();
				Label11.Text = Session["Room_Type"].ToString();
				//抓現在時間
				date1 = DateTime.Now.Date;
			}

		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session["Food"] = DropDownList1.SelectedValue.ToString();
		}

		protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session["Bed"] = DropDownList2.SelectedValue.ToString();
		}

		protected void Calendar1_SelectionChanged(object sender, EventArgs e)
		{
			Session["Expiration_Date"] = Calendar1.SelectedDate.ToShortDateString();
		}

		//信用卡卡號驗證
		public bool CreditCard_Number_Check(string CreditCard_Number)
		{
			// 使用「正規表達式」檢驗格式  [0~9] {16}個數字
			bool flag = Regex.IsMatch(CreditCard_Number, @"^[0-9]{16}$");
			return flag;
		}
		//安全碼驗證
		public bool Security_Code_Check(string Security_Code)
		{
			// 使用「正規表達式」檢驗格式  [0~9] {3}個數字
			bool flag = Regex.IsMatch(Security_Code, @"^[0-9]{3}$");
			return flag;
		}
		//持卡人姓名驗證
		public bool Name_On_CreditCard_Check(string Name_On_CreditCard)
		{
			// 使用「正規表達式」檢驗格式 英文字1~30個字
			bool flag = Regex.IsMatch(Name_On_CreditCard, @"^[A-Za-z]{1,30}$");
			return flag;
		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			CreditCard_Number = TextBox1.Text;
			Security_Code = TextBox2.Text;
			Name_On_CreditCard = TextBox3.Text;
			// null 判斷
			if (TextBox1.Text == null)
			{
				Label12.Text = "請輸入信用卡卡號";

			}
			else if (Session["Expiration_Date"] == null)
			{
				Label12.Text = "請選擇信用卡到期日期";
			}
			else if (date1 >= Convert.ToDateTime(Session["Expiration_Date"]))
			{
				Label12.Text = "信用卡到期日期不能早於今天";
			}
			else if (TextBox2.Text == null)
			{
				Label12.Text = "請輸入安全碼";
			}
			else if (TextBox3.Text == null)
			{
				Label12.Text = "請輸入持卡人姓名";
			}
			// 格式錯誤判斷
			else if (CreditCard_Number_Check(CreditCard_Number) == false)
			{
				Label12.Text = "信用卡卡號格式錯誤,請輸入16位數字";
			}
			else if (Security_Code_Check(Security_Code) == false)
			{
				Label12.Text = "安全碼格式錯誤,請輸入3位數字";
			}
			else if (Name_On_CreditCard_Check(Name_On_CreditCard) == false)
			{
				Label12.Text = "持卡人姓名格式錯誤,請輸入1~30個英文字母";
			}
			else
			{
				// 如果沒選預設是0
				if (Session["Food"] == null)
				{
					Session["Food"] = "0";
				}
				if (Session["Bed"] == null)
				{
					Session["Bed"] = "0";
				}
				// 不跳出錯誤訊息
				Label12.Text = null;
				//開啟連線
				SqlConnection conn = new SqlConnection(data);
				conn.Open();
				//寫入訂單之前再度確認有無重複
				SqlCommand cmd_1 = new SqlCommand();
				cmd_1.Connection = conn;
				cmd_1.CommandText = "Check_Ins_Order";
				cmd_1.CommandType = CommandType.StoredProcedure;
				//宣告參數和給值
				cmd_1.Parameters.Add("@Start_Date", SqlDbType.DateTime);
				cmd_1.Parameters["@Start_Date"].Value = Session["Start_Date"];
				cmd_1.Parameters.Add("@End_Date", SqlDbType.DateTime);
				cmd_1.Parameters["@End_Date"].Value = Session["End_Date"];
				cmd_1.Parameters.Add("@Customer_ID", SqlDbType.Int);
				cmd_1.Parameters["@Customer_ID"].Value = Session["ID"];
				cmd_1.Parameters.Add("@Room_Type", SqlDbType.NVarChar);
				cmd_1.Parameters["@Room_Type"].Value = Session["Room_Type"];
				SqlDataReader dr = cmd_1.ExecuteReader();
				GridView1.DataSource = dr;
				GridView1.DataBind();
				dr.Close();


				// 寫進訂單
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = "Ins_Order";
				cmd.CommandType = CommandType.StoredProcedure;
				//宣告參數和給值
				cmd.Parameters.Add("@Start_Date", SqlDbType.DateTime);
				cmd.Parameters["@Start_Date"].Value = Session["Start_Date"];
				cmd.Parameters.Add("@End_Date", SqlDbType.DateTime);
				cmd.Parameters["@End_Date"].Value = Session["End_Date"];
				cmd.Parameters.Add("@Customer_ID", SqlDbType.Int);
				cmd.Parameters["@Customer_ID"].Value = Session["ID"];
				cmd.Parameters.Add("@Room_Type", SqlDbType.NVarChar);
				cmd.Parameters["@Room_Type"].Value = Session["Room_Type"];
				cmd.Parameters.Add("@Food", SqlDbType.NVarChar);
				cmd.Parameters["@Food"].Value = Session["Food"];
				cmd.Parameters.Add("@Bed", SqlDbType.NVarChar);
				cmd.Parameters["@Bed"].Value = Session["Bed"];
				cmd.Parameters.Add("@CreditCard_Number", SqlDbType.NVarChar);
				cmd.Parameters["@CreditCard_Number"].Value = TextBox1.Text.ToString();
				cmd.Parameters.Add("@Expiration_Date", SqlDbType.DateTime);
				cmd.Parameters["@Expiration_Date"].Value = Session["Expiration_Date"];
				cmd.Parameters.Add("@Security_Code", SqlDbType.NVarChar);
				cmd.Parameters["@Security_Code"].Value = TextBox2.Text.ToString();
				cmd.Parameters.Add("@Name_On_CreditCard", SqlDbType.NVarChar);
				cmd.Parameters["@Name_On_CreditCard"].Value = TextBox3.Text.ToString();
				cmd.ExecuteNonQuery();

				//找 同一個客戶 訂單有幾筆資料
				SqlCommand cmd_order = new SqlCommand($"select count(*) from [Order] where Customer_ID=@ID", conn);
				//宣告參數和給值
				cmd_order.Parameters.Add("@ID", SqlDbType.Int);
				cmd_order.Parameters["@ID"].Value = Session["ID"];
				SqlDataReader dr_order = cmd_order.ExecuteReader();
				while (dr_order.Read())
				{
					Num_New = (int)dr_order[0];
				}
				dr_order.Close();

				//如果訂單數有有增加才開始寄信
				if (Num_New != Num)
				{
					// 設定信件內容
					SqlCommand cmd_mail = new SqlCommand();
					cmd_mail.Connection = conn;
					cmd_mail.CommandText = "Show_Mail_Content";
					cmd_mail.CommandType = CommandType.StoredProcedure;
					//宣告參數和給值
					cmd_mail.Parameters.Add("@Customer_ID", SqlDbType.Int);
					cmd_mail.Parameters["@Customer_ID"].Value = Session["ID"];
					SqlDataReader dr_mail = cmd_mail.ExecuteReader();
					if (dr_mail.Read())
					{
						Session["Order_ID"] = dr_mail[0];
						Session["Customer_Name"] = dr_mail[1];
						Session["Order_Date"] = dr_mail[2];
						Session["Room_Type"] = dr_mail[3];
						Session["Start_Date"] = dr_mail[4];
						Session["End_Date"] = dr_mail[5];
						Session["Food"] = dr_mail[6];
						Session["Bed"] = dr_mail[7];
						Session["Price"] = dr_mail[8];
					}
					dr_mail.Close();
					sendGmail();
				}
				conn.Close();
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("Index.aspx");
			//下完訂單清掉 Session
			Session["Start_Date"] = null;
			Session["End_Date"] = null;
		}

		public void sendGmail()
		{
			MailMessage mail = new MailMessage();
			//前面是發信email後面是顯示的名稱
			mail.From = new MailAddress("benchenhsnu@gmail.com", "訂房通知");

			//收信者email
			mail.To.Add(Session["Email"].ToString());

			//設定優先權
			mail.Priority = MailPriority.Normal;

			//標題
			mail.Subject = "您的訂房成功通知";

			//內容
			mail.Body = "<h1>" + Session["Customer_Name"] + "您好</h1><br /><h1>感謝您預定 Winter Inn，以下是您的訂單資訊:</h1><br /><h2>1.訂單編號:" + Session["Order_ID"] + "<br />2.下單日期:" + Session["Order_Date"] +
				"<br />3.預定的房型:" + Session["Room_Type"] + "<br />4.入住日期:" + Session["Start_Date"] + "<br />5.退房日期:" + Session["End_Date"] + "<br />6.餐點數量:" + Session["Food"] + "<br />7.加床數量:" + Session["Bed"] +
				"<br />8.單筆總價:" + Session["Price"] + "</h2><br /><br />若有任何問題，歡迎到官網訂單查詢(超連結到訂單查詢頁面)或Q&A(超連結到網頁留言版)進行提問祝您有個愉快的假期<br /><br />Winter Inn";

			//內容使用html
			mail.IsBodyHtml = true;

			//設定gmail的smtp (這是google的)
			SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

			//您在gmail的帳號密碼
			MySmtp.Credentials = new System.Net.NetworkCredential("benchenhsnu", "cndlszchqikmvdus");

			//開啟ssl
			MySmtp.EnableSsl = true;

			//發送郵件
			MySmtp.Send(mail);

			//放掉宣告出來的MySmtp
			MySmtp = null;

			//放掉宣告出來的mail
			mail.Dispose();
		}

	}

}