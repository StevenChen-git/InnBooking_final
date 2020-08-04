<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InnBooking.Index" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div>
      <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <a class="navbar-brand" >Winter Inn</a><button class="btn btn-link btn-sm order-1 order-lg-0" id="sidebarToggle" ><i class="fas fa-bars"></i></button
            >
         <a class="navbar-brand" > User:   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a> 
         
          <!-- Navbar Search-->

            <!-- Navbar-->
            <ul class="navbar-nav ml-auto ml-md-0">
                <li class="nav-item dropdown">
                   <a class="nav-link dropdown-toggle" id="userDropdown" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fas fa-user fa-fw"></i></a>

                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="userDropdown">

                        <div class="dropdown-divider"></div>
                      <a class="dropdown-item"   <asp:LinkButton ID="logout_b" runat="server" OnClick="logout_b_Click" enableviewstate="True" visible="True">Logout</asp:LinkButton></a>
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
                            <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapsePages" aria-expanded="true" aria-controls="collapsePages"
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
<!--                                  <div class="collapse" id="pagesCollapseAuth" aria-labelledby="headingOne" data-parent="#sidenavAccordionPages">
                                        <nav class="sb-sidenav-menu-nested nav"><a class="nav-link" href="login.html">Login</a><a class="nav-link" href="register.html">Register</a><a class="nav-link" href="password.html">Forgot Password</a></nav>
                                    </div>
                                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#pagesCollapseError" aria-expanded="true" aria-controls="pagesCollapseError"
                                        >Order Tracking
                                        <div class="sb-sidenav-collapse-arrow"><i class=""></i></div
                                    ></a>
--><!--                                    <div class="collapse" id="pagesCollapseError" aria-labelledby="headingOne" data-parent="#sidenavAccordionPages">
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
<!--   Content        -->
                <main>

 <div class="container"> 

    <div class="row">
                      <div class="col-lg-3">

        <h1 class="my-4">Winter Inn</h1>
        <h3>最新資訊</h3>
        <div class="list-group">
          <a target="_blank" href="https://bravekeyservers--zoloer.repl.co/car" class="list-group-item">租車資訊</a>
          <a target="_blank" href="https://bravekeyservers--zoloer.repl.co/car2" class="list-group-item">租車資訊</a>
          <a target="_blank" href="https://bravekeyservers--zoloer.repl.co/ETtoday" class="list-group-item">新聞資訊</a>
            <a target="_blank" href="RQuery_Room.aspx" class="list-group-item">房間預定</a>
            <a target="_blank" href="Member.aspx" class="list-group-item">會員專區</a>        
            <a target="_blank" href="Message_index.aspx" class="list-group-item">留言專區</a>
        

            
               <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="250px">
                   <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                   <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                   <OtherMonthDayStyle ForeColor="#999999" />
                   <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                   <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                   <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
        </div>
                          <br/>

<div class="mapouter"><div class="gmap_canvas"><iframe width="250" height="250" id="gmap_canvas" src="https://maps.google.com/maps?q=10049%E5%8F%B0%E5%8C%97%E5%B8%82%E4%B8%AD%E6%AD%A3%E5%8D%80%E5%BF%A0%E5%AD%9D%E6%9D%B1%E8%B7%AF12%20Section%201&t=&z=13&ie=UTF8&iwloc=&output=embed" 
    frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe><a href="https://www.embedgooglemap.net">google map generator</a></div><style>.mapouter{position:relative;text-align:right;height:250px;width:250px;}.gmap_canvas {overflow:hidden;background:none!important;height:250px;width:250px;}</style></div>
      </div>    

      <!-- /.col-lg-3 -->

      <div class="col-lg-9">

        <div id="carouselExampleIndicators" class="carousel slide my-4" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          </ol>
          <div class="carousel-inner" role="listbox">
            <div class="carousel-item active">
             <!-- <img class="d-block img-fluid" src="http://placehold.it/900x350" alt="First slide">-->
                <asp:Image ID="Image1" runat="server" ImageUrl="Images/01.jpg" img class="d-block img-fluid"  alt="First slide" />
            </div>
            <div class="carousel-item">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/02.jpg" img class="d-block img-fluid"  alt="First slide" />
            </div>
            <div class="carousel-item">
              <asp:Image ID="Image3" runat="server" ImageUrl="Images/03.jpg" img class="d-block img-fluid"  alt="First slide" />
            </div>
          </div>
          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div>


 
            
                <!--<a href="#"><img class="card-img-top" src="http://placehold.it/700x400" alt=""></a>-->

                <div class="card mb-4">
                    <div class="card-header"> <h4>Room List</h4></div>  
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                 </div>

        </div>
        <!-- /.row -->

      </div>
      <!-- /.col-lg-9 -->

     </div> 
    <!-- /.row -->

 

                </main>
<!--   Content   fin     -->
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