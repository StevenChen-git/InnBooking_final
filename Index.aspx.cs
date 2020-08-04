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
    public partial class Index : System.Web.UI.Page
    {
        string data;
        public int Num;
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
            //找Room有幾筆資料
            SqlCommand cmd_room = new SqlCommand($"select count(*) from Room", conn);
            conn.Open();
            SqlDataReader dr_room = cmd_room.ExecuteReader();
            while (dr_room.Read())
            {
                Num = (int)dr_room[0];
            }
            dr_room.Close();

            for (int i = 1; i < Num + 1; i++)
            {
                Image Image = new Image();
                Image.ID = "Room_" + i.ToString();
                Label Type = new Label();
                Type.ID = "Type_" + i.ToString();
                Label Price = new Label();
                Price.ID = "Price_" + i.ToString();
                Label Detail = new Label();
                Detail.ID = "Detail_" + i.ToString();
                PlaceHolder PlaceHolder = new PlaceHolder();
                PlaceHolder.ID = "PlaceHolder_" + i.ToString();

                PlaceHolder1.Controls.Add(PlaceHolder);


                //((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<div class=\"col-lg-4 col-md-6 mb-4\">"));   //col-lg-4 col-md-6 mb-4
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<div class=\"card h - 100\">"));   //card h -100

                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<div class=\"row\">"));            //row
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<div class=\"card-header\">"));    // div-1
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(Image);
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</div>"));                         //  /div-1
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<div class=\"col-6 m-3\">"));   //  div-2
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<h4> Type: "));                           //h4
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl(string.Format("<a href = \"Room0{0}.aspx \">", i.ToString())));
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(Type);
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</h4>"));                           // /h4
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</a>"));
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<h5> 價錢: "));                           //h5
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(Price);
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</h5>"));                          // /h5
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("<h5> 設備: "));                           //h5
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(Detail);
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</h5>"));                          // /h5
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</div>"));                         //  /div-2
                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</div>"));                          // /row

                ((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</div>"));                          // /card h -100
                                                                                                                                                   //((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</div>"));                         // /col-lg-4 col-md-6 mb-4
                                                                                                                                                   //((PlaceHolder)FindControl(id: "PlaceHolder_" + i.ToString())).Controls.Add(new LiteralControl("</div>"));


                //顯示圖片
               SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Show_Room_Image";
                cmd.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd.Parameters.Add("@Room_ID", SqlDbType.Int);
                cmd.Parameters["@Room_ID"].Value = i;
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                ((Image)FindControl(id: "Room_" + i.ToString())).ImageUrl = "data:Image/jpg;base64," + strBase64;
                ((Image)FindControl(id: "Room_" + i.ToString())).Height = 200;
                ((Image)FindControl(id: "Room_" + i.ToString())).Width = 260;



                // 顯示房型和詳細資訊
                SqlCommand cmd_1 = new SqlCommand();
                cmd_1.Connection = conn;
                cmd_1.CommandText = "Show_Room_Detail";
                cmd_1.CommandType = CommandType.StoredProcedure;
                //宣告參數和給值
                cmd_1.Parameters.Add("@Room_ID", SqlDbType.Int);
                cmd_1.Parameters["@Room_ID"].Value = i;
                SqlDataReader dr = cmd_1.ExecuteReader();
                while (dr.Read())
                {
                    ((Label)FindControl(id: "Type_" + i.ToString())).Text = dr[0].ToString();
                    ((Label)FindControl(id: "Price_" + i.ToString())).Text = dr[1].ToString();
                    ((Label)FindControl(id: "Detail_" + i.ToString())).Text = dr[2].ToString();
                }
                dr.Close();

            }
            conn.Close();
        }
        protected void logout_b_Click(object sender, EventArgs e)
        {
            Session["Account"] = null;
            Response.Redirect("Index.aspx");
        }


    }
}