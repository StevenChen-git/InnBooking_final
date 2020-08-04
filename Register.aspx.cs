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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] == null)
            {
                Label1.Text = "Guest";
                //logout_b.Visible = false;
            }
            else
            {
                Label1.Text = Convert.ToString(Session["Account"]);
            }
        }
        protected void logout_b_Click(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("Index.aspx");
        }
        protected void LoginPage_b_Click1(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Submit_b_Click1(object sender, EventArgs e)
        {
            //SQL指令:利用玩家輸入的帳號去資料庫搜尋會員密碼,以進行比對

            this.vid = account.Text;
            this.vp = passwd.Text;
            this.vn = name.Text;
            this.vc = cell.Text;
            this.vm = email.Text;

            check_DB();


            if (this.vid.Length > 2 && this.vp.Length > 2 && this.vn.Length > 2 && this.vc.Length > 9 && vm.Length>1 && dbv == true)
            {
                string s_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Global.ConnectionString].ConnectionString;
                SqlConnection conn = new SqlConnection(s_data);
                conn.Open(); //開啟資料庫
                SqlCommand cmd = new SqlCommand("insert into [Customer] (Account, Password, Name, Phone, Email) values (@ID, @PD, @NA, @CE, @EM)", conn);
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = id;
                cmd.Parameters.Add("@PD", SqlDbType.NVarChar).Value = p;
                cmd.Parameters.Add("@NA", SqlDbType.NVarChar).Value = n;
                cmd.Parameters.Add("@CE", SqlDbType.NVarChar).Value = c;
                cmd.Parameters.Add("@EM", SqlDbType.NVarChar).Value = m;
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                Response.Write("<Script language='JavaScript'>alert('Register Complete\\r Return to Login');window.location = 'login.aspx';</Script>");
                //Response.Redirect("login.aspx");
            }

        }
        bool dbv = true;
        private string id;
        private string p;
        private string n;
        private string c;
        private string m;
        public string vid
        {
            get { return id; }
            set
            {
                if ((Regex.IsMatch(value, @"[A-z]{1}")) && value.Length > 2)
                {
                    id = value;
                    al.Text = "[OK]";
                    dbv = true;
                }


                else
                {
                    if (Regex.IsMatch(value, @"[A-z]{1}"))
                    {
                        al.Text = "#[Account needs over 3 words]";
                    }
                    else if (value.Length > 2)
                    {
                        al.Text = "#[Account needs start with alphabet]";
                    }
                    else
                    {
                        al.Text = "#[Account needs start with alphabet & over 3 words]";
                    }
                    id = "";

                }

            }
        }

        public string vp
        {
            get { return p; }
            set
            {
                if (value.Length > 5)
                {
                    p = value;
                    al2.Text = "[OK]";
                }
                else
                {
                    al2.Text = "#[Password needs over 6 words]";
                    p = "";
                }
                
            }
        }

        public string vn
        {
            get { return n; }
            set
            {
                if ((Regex.IsMatch(value, @"[A-z]{1}")) && value.Length > 2)
                {
                    n = value;
                    al3.Text = "[OK]";
                }
                else
                {
                    if (Regex.IsMatch(value, @"[A-z]{1}"))
                    {
                        al3.Text = "#[Account needs over 3 words]";
                    }
                    else if (value.Length > 2)
                    {
                        al3.Text = "#[Full name needs start with alphabet]";
                    }
                    else
                    {
                        al3.Text = "#[Name needs start with alphabet & over 3 words]";
                    }
                    n = "";
                }
            }
        }


        public string vc
        {
            get { return c; }
            set
            {
                if ((Regex.IsMatch(value, @"[0]{1}[9]{1}")) && value.Length == 10)
                {
                    c = value;
                    al4.Text = "[OK]";
                }
                else
                {
                    if (Regex.IsMatch(value, @"[0]{1}[9]{1}"))
                    {
                        al4.Text = "#[Cell phine needs comply with 10 words]";
                    }
                    else if (value.Length > 2)
                    {
                        al4.Text = "#[Cell phine needs start with 09]";
                    }
                    else
                    {
                        al4.Text = "#[Cell phine needs start with 09 and with 10 words]";
                    }
                    c = "";
                }

            }
        }
        public string vm
        {
            get { return m; }
            set
            {
                if (Regex.IsMatch(value, "[^/w+((-+.)/w+)*@/w+((-.)/w+)*/./w+((-.)/w+)*$]"))
                {
                    m = value;
                    al5.Text = "[OK]";
                }
                else
                {
                    al5.Text = "#[Email format error]";
                    m = "";
                }

            }
        }

        public void check_DB()
        {
            string c_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Global.ConnectionString].ConnectionString;
            SqlConnection conn = new SqlConnection(c_data);
            conn.Open(); //開啟資料庫
            SqlCommand cmd = new SqlCommand("select Name from [Customer] where Account=@ID", conn);

            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = account.Text;
            //cmd.Parameters.Add("@PD", SqlDbType.NVarChar).Value = passwd.Text;
            SqlDataReader d = cmd.ExecuteReader();

            if (d.HasRows) //如果有抓到資料
            {
                if (d.Read())
                {
                    al.Text = "Account have exist";
                    dbv = false;
                }
            }


            d.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }


    }
}