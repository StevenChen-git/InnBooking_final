<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Room01.aspx.cs" Inherits="InnBooking.Room01" %>

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



  <link rel="stylesheet" href="style.css" />


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
        <!-- Preloader -->
    <div id="preloader">
        <div class="loader"></div>
    </div>
    <!-- /Preloader -->

    <!-- Header Area Start -->
        <div class="breadcrumb-area bg-img bg-overlay jarallax" style="background-image: url(img/bg-img/16.jpg);">
        <div class="container h-100">
            <div class="row h-100 align-items-end">
                <div class="col-12">
                    <div class="breadcrumb-content d-flex align-items-center justify-content-between pb-5">
                        <h2 class="room-title">Room View</h2>
                        <h2 class="room-price"> <span></span></h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Header Area End -->

    <!-- Breadcrumb Area Start -->
    
    <!-- Breadcrumb Area End -->

    <!-- Rooms Area Start -->
    <div class="roberto-rooms-area section-padding-100-0">
        <div class="container">
            <div class="row">
                <div class="col-12 col-lg-8">
                    <!-- Single Room Details Area -->
                    <div class="single-room-details-area mb-50">
                        <!-- Room Thumbnail Slides -->
                        <div class="room-thumbnail-slides mb-50">
                            <div id="room-thumbnail--slide" class="carousel slide" data-ride="carousel">
                                <div class="carousel-inner">
                                    <div class="carousel-item active">
                                        <img src="img/01.jpg" class="d-block w-100" alt="">
                                    </div>
                                    <div class="carousel-item" >
                                        <img src="img/02.jpg" class="d-block w-100" alt="">
                                    </div>
                                    <div class="carousel-item">
                                        <img src="img/03.jpg" class="d-block w-100" alt="">
                                    </div>

                                </div>

                                <ol class="carousel-indicators">
                                    <li data-target="#room-thumbnail--slide" data-slide-to="0" class="active">
                                        <img src="img/01.jpg" class="d-block w-100" alt="">
                                    </li>
                                    <li data-target="#room-thumbnail--slide" data-slide-to="1">
                                        <img src="img/02.jpg" class="d-block w-100" alt="">
                                    </li>
                                    <li data-target="#room-thumbnail--slide" data-slide-to="2">
                                        <img src="img/03.jpg" class="d-block w-100" alt="">

                                    </li>
                                </ol>
                            </div>
                        </div>

                        <!-- Room Features -->




                       
                    </div>

                    <!-- Room Service -->


                    <!-- Room Review -->
                    
                </div>

                <div class="col-12 col-lg-4">
     <!-- Hotel Reservation Area -->
                    <div class="hotel-reservation--area mb-100">
                        
                            
                               <div class="card-body">

                                   <h4>Room Feature</h4>

                                     <h4>房型</h4>
                                        <h5>
                                     <a href="#">
                                        <span><asp:Label ID="Type_1" runat="server" ForeColor="#CC6699"></asp:Label></span>
                                     </a>
                                        </h5>
                                     <h4>價錢</h4>
                                        <h5><span><asp:Label ID="Price_1" runat="server" ForeColor="#CC6699"></asp:Label>/Per night</span></h5>
                                     <h4>設備</h4>
                                     <p class="card-text">
                                        <h5><span><asp:Label ID="Detail_1" runat="server" ForeColor="#CC6699"></asp:Label></span></h5>
                                     </p>

                                                       <div class="room-service mb-50">
     
                                                           
                 <h4>Room Services</h4>

                        <ul>
                            
                            <li><img src="img/core-img/icon2.png" alt=""> Free drinks</li>
                            
                            <li><img src="img/core-img/icon4.png" alt=""> Cable TV</li>
                            <li><img src="img/core-img/icon1.png" alt=""> Air Conditioning</li>
                            <li><img src="img/core-img/icon5.png" alt=""> Unlimited Wifi</li>
                            <li><img src="img/core-img/icon6.png" alt=""> Service 24/24</li>

                            <li><img src="img/core-img/icon3.png" alt=""> Restaurant quality</li>
                        </ul>
                    </div>
                               </div>
                    </div>
     <!-- Hotel Reservation Area -->
                </div>
            </div>
        </div>
    </div>
    <!-- Rooms Area End -->

    <!-- Call To Action Area Start -->
    
    <!-- Call To Action Area End -->

    <!-- Partner Area Start -->
    
    <!-- Partner Area End -->

    <!-- Footer Area Start -->
    
    <!-- Footer Area End -->

    <!-- **** All JS Files ***** -->
    <!-- jQuery 2.2.4 -->
    <script src="js/jquery.min.js"></script>
    <!-- Popper -->
    <script src="js/popper.min.js"></script>
    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js"></script>
    <!-- All Plugins -->
    <script src="js/roberto.bundle.js"></script>
    <!-- Active -->
    <script src="js/default-assets/active.js"></script>







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