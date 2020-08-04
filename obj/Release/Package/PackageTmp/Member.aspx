<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="InnBooking.Member" %>

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
         <a class="navbar-brand" > User:   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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
                      <h1 class="mt-4">用戶詳細資料</h1>
         
    </div>
    <ol class="breadcrumb mb-4">
</ol>
    &nbsp;<div align="center" valign="center">
            
              
            <div>
              <asp:Button ID="Edit_Room_b" runat="server" Text="新增/修改房間資料" CssClass="btn-secondary" Width="40%" Height="100%" OnClick="Edit_Room_b_Click" /><br/>&nbsp;&nbsp;&nbsp;&nbsp;

			</div>	
                <div class="form-group">
                    <label for="Account" class="col-sm-3 control-label">姓名</label>
                    <div class="col-sm-4">
                        
                        <asp:TextBox ID="name" placeholder="" class="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
				<div class="form-group">
                    <label for="ID" class="col-sm-3 control-label">ID</label>
                    <div class="col-sm-4">
                        
                        <asp:TextBox ID="ID" placeholder="" class="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
     			<div class="form-group">
                    <label for="ID" class="col-sm-3 control-label">電話號碼 </label>
                    &nbsp;<div class="col-sm-4">
                        
                        <asp:TextBox ID="phone" placeholder="" class="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
          		<div class="form-group">
                    <label for="ID" class="col-sm-3 control-label">帳號</label>
                    <div class="col-sm-4">
                        
                        <asp:TextBox ID="account" placeholder="" class="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
               		<div class="form-group">
                    <label for="ID" class="col-sm-3 control-label">密碼</label>
                    <div class="col-sm-4">
                        
                        <asp:TextBox ID="password" placeholder="" class="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>

                 <div class="form-group">
                    <label for="ID" class="col-sm-3 control-label">信箱</label>
                    <div class="col-sm-4">
                        
                        <asp:TextBox ID="email" placeholder="" class="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
     <br/>
              <asp:Button ID="Order_chk_b" runat="server" Text="查詢訂單資料" CssClass="btn-dark" Width="35%" Height="100%" OnClick="Order_chk_b_Click" /><br/><br/>

   
                <div class="form-group">
                    <div class="col-md-3 col-sm-offset-3">
                        <div>
                            <ul>
                            
                            <li><img src="img/QR.png" alt="" /> Line查詢服務</li>
                            

                           </ul>


                        </div>
                    </div>
    
    </div>            
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