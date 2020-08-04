﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maintain.aspx.cs" Inherits="InnBooking.Maintain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
          <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Tables - SB Admin</title>
        <link href="css/styles.css" rel="stylesheet" />
        <link href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css" rel="stylesheet" crossorigin="anonymous" />
        <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.11.2/js/all.min.js" crossorigin="anonymous"></script>

      

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>






</head>
<body>
    
   <form class="form-horizontal" role="form" runat="server">
        <div>
      <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <a class="navbar-brand" href="index.aspx">Winter Inn</a><button class="btn btn-link btn-sm order-1 order-lg-0" id="sidebarToggle" href="#"><i class="fas fa-bars"></i></button
            >
         <a class="navbar-brand" > User:   <asp:Label ID="user" runat="server" Text=""></asp:Label>
         </a> <!-- Navbar Search-->

            <!-- Navbar-->
            <ul class="navbar-nav ml-auto ml-md-0">
                <li class="nav-item dropdown">
                   <a class="nav-link dropdown-toggle" id="userDropdown" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fas fa-user fa-fw"></i></a>

                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="userDropdown">

                        <div class="dropdown-divider"></div>

                      <a class="dropdown-item"<asp:LinkButton ID="logout_b" runat="server" OnClick="logout_b_Click" enableviewstate="True" visible="True">Logout</asp:LinkButton></a>
                    </div>
                </li>
            </ul>
        </nav>
        <div id="layoutSidenav">
            <div id="layoutSidenav_nav">
                <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                    <div class="sb-sidenav-menu">
                        <div class="nav">
                            <div class="sb-sidenav-menu-heading"></div>
                            <a class="nav-link" href="index.aspx"
                                ><div class="sb-nav-link-icon"><i class="fas fa-tachometer-alt"></i></div>
                                Home</a>
                            
<!--                            <div class="sb-sidenav-menu-heading">Interface</div>
-->
<!--                             <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseLayouts" aria-expanded="false" aria-controls="collapseLayouts" > 
-->                            
                             <a class="nav-link" href="RQuery_Room.aspx">
                                <div class="sb-nav-link-icon"><i class="fas fa-columns"></i></div>
                                Reservation 
<!--                               <div class="sb-sidenav-collapse-arrow"><i class="fas fa-angle-down"></i></div >
-->   
                            </a>
<!--                            <div class="collapse" id="collapseLayouts" aria-labelledby="headingOne" data-parent="#sidenavAccordion">
                                <nav class="sb-sidenav-menu-nested nav"><a class="nav-link" href="layout-static.html">Static Navigation</a>
                                    <a class="nav-link" href="layout-sidenav-light.html">Light Sidenav</a></nav>
                            </div>
-->
                            <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapsePages" aria-expanded="false" aria-controls="collapsePages"
                                ><div class="sb-nav-link-icon"><i class="fas fa-book-open"></i></div>
                                Member Area
                                <div class="sb-sidenav-collapse-arrow"><i class="fas fa-angle-down"></i></div
                            ></a>
                            <div class="nav-link" >
                                <nav class="sb-sidenav-menu-nested nav accordion" id="sidenavAccordionPages">
    
                                    <a class="nav-link collapsed" data-toggle="collapse" data-target="#pagesCollapseAuth" aria-expanded="true" aria-controls="pagesCollapseAuth">  
                                    </a>
                                        <a class="nav-link" href="login.aspx">Login</a>
                                        <a class="nav-link" href="Member.aspx">Member Data</a>
                                        <a class="nav-link" href="RQuery_check.aspx">Order Tracking</a>
                                        <div class="sb-sidenav-collapse-arrow"><i class=""></i></div>

<!--                                      <a class="nav-link collapsed" href="Register.aspx" data-toggle="collapse" data-target="#pagesCollapseError" aria-expanded="true" aria-controls="pagesCollapseError"
                                        >Order Tracking
                                        <div class="sb-sidenav-collapse-arrow"><i class=""></i></div
                                    ></a>
<!--                                    <div class="collapse" id="pagesCollapseError" aria-labelledby="headingOne" data-parent="#sidenavAccordionPages">
                                    <nav class="sb-sidenav-menu-nested nav"><a class="nav-link" href="401.html">401 Page</a><a class="nav-link" href="404.html">404 Page</a><a class="nav-link" href="500.html">500 Page</a></nav>
                                    </div>
--> 
                                </nav>

                           </div>
                             <div class="sb-sidenav-menu-heading">Contact US</div>
                            <a class="nav-link" href="Message_index.aspx">
                                <div class="sb-nav-link-icon"><i class="fas fa-chart-area"></i></div>
                                FAQs</a>
<!--                           <a class="nav-link" href="tables.html">
                                <div class="sb-nav-link-icon"><i class="fas fa-table"></i></div>
                                Tables</a>
-->                     
                                </div>

                             </div>


                    <div class="sb-sidenav-footer">
                        <div class="small">Logged in as:</div>
                        
                        Start Bootstrap
                    </div>
                </nav>
            </div>
            <div id="layoutSidenav_content">

<!--   Content           -->

                <main>
<div class="container-fluid">
    <div class="row justify-content-center">
                      <h1 class="mt-4">Maintain Room Data</h1>
    </div>
    <ol class="breadcrumb mb-4">
</ol>
<div class =" col-lg-10 offset-lg-4 ">
    <h4>
            <asp:Label ID="Label19" runat="server" Text="新增房型"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="輸入設定房型"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="輸入設定房型價錢"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="選擇房型詳細資訊"></asp:Label>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="衛浴設備" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox2" runat="server" Text="浴缸" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox3" runat="server" Text="吹風機" OnCheckedChanged="CheckBox3_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox4" runat="server" Text="冰箱" OnCheckedChanged="CheckBox4_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox5" runat="server" Text="盥洗用品" OnCheckedChanged="CheckBox5_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox6" runat="server" Text="KTV" OnCheckedChanged="CheckBox6_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox7" runat="server" Text="保險箱" OnCheckedChanged="CheckBox7_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox8" runat="server" Text="游泳池" OnCheckedChanged="CheckBox8_CheckedChanged" AutoPostBack="true"/>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="選擇設定房型圖片" Width="20%"></asp:Label>
            <br />
            <asp:FileUpload runat="server" ID="FileUpload1"></asp:FileUpload>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確認新增" CssClass="btn-dark" Width="20%" />
            <br />
            <asp:Label ID="Label15" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="我要更新房型" CssClass="btn-dark" Width="20%" />
            <br />

            <br />
            <asp:Label ID="Label11" runat="server" Text="選擇更新房型"></asp:Label>
            <br />



     <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
     </asp:DropDownList>



            
            <br />
            <br />
            <asp:Label ID="Label12" runat="server" Text="輸入更新房型價錢"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label13" runat="server" Text="選擇更新房型詳細資訊"></asp:Label>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox9" runat="server" Text="衛浴設備" OnCheckedChanged="CheckBox9_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox10" runat="server" Text="浴缸" OnCheckedChanged="CheckBox10_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox11" runat="server" Text="吹風機" OnCheckedChanged="CheckBox11_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox12" runat="server" Text="冰箱" OnCheckedChanged="CheckBox12_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox13" runat="server" Text="盥洗用品" OnCheckedChanged="CheckBox13_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox14" runat="server" Text="KTV" OnCheckedChanged="CheckBox14_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox15" runat="server" Text="保險箱" OnCheckedChanged="CheckBox15_CheckedChanged" AutoPostBack="true"/>
            <asp:CheckBox ID="CheckBox16" runat="server" Text="游泳池" OnCheckedChanged="CheckBox16_CheckedChanged" AutoPostBack="true"/>
            <br />
            <br />
            <asp:Label ID="Label14" runat="server" Text="選擇房型圖片"></asp:Label>
            <br />
            <asp:FileUpload runat="server" ID="FileUpload2"></asp:FileUpload>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="確認更新" CssClass="btn-dark" Width="20%" />
            <br />
            <asp:Label ID="Label16" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="我要刪除房型" CssClass="btn-dark" Width="20%" />
            <br />
            <br />
            <asp:Label ID="Label20" runat="server" Text="選擇刪除房型"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="確認刪除" CssClass="btn-dark" Width="20%" />
            <br />
            <asp:Label ID="Label21" runat="server"></asp:Label>
            <br />
            <br />
	    
	






    </h4>>
</div>
</div>
                </main>
<!--   /Content   fin     -->
                <footer class="py-4 bg-dark mt-auto">
                    <div class="container-fluid">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; Your Website 2019</div>
                            <div>
                                <a href="#">Privacy Policy</a>
                                &middot;
                                <a href="#">Terms &amp; Conditions</a>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
        <script src="https://code.jquery.com/jquery-3.4.1.min.js" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="js/scripts.js"></script>
        <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" crossorigin="anonymous"></script>
        <script src="assets/demo/datatables-demo.js"></script>
        </div>
    </form>
        
</body>
</html>