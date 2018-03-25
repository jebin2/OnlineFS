<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminindex.aspx.cs" Inherits="AdminIndex" %>

<!DOCTYPE html>
<html lang="en">

  <head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Home</title>

    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="css/blog-home.css" rel="stylesheet">

  </head>

  <body>

    <!-- Navigation -->
    <form id="postticket" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <div class="container">
        <a class="navbar-brand" href="#">Home</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
          <ul class="navbar-nav ml-auto">
            <li class="nav-item" id = "login" runat = "server">
              <!--<a class="nav-link" href="/default.aspx" runat = "server">Login</a>-->
              <asp:Button ID="login22" CssClass="btn nav-link btn-link" runat="server" Text="Login" OnClick="fLogin"></asp:Button>
            </li>
            <li class="nav-item" id = "logout" runat = "server">
              <!--<a class="nav-link" href="/default.aspx" runat = "server">Logout</a>-->
              <asp:Button ID="logout22" CssClass="btn nav-link btn-link" runat="server" Text="Logout" OnClick="fLogout"></asp:Button>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">About</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <!-- Page Content -->
    <div class="container">

      <div class="row">

        <!-- Blog Entries Column -->
        <div class="col-md-8">

          <h1 class="my-4">Posts
            <small></small>
          </h1>

          <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:Repeater runat="server" ID="rptItems"></asp:Repeater>

          <!-- Blog Post
          <div class="card mb-4">
            <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap">
            <div class="card-body">
              <h2 class="card-title" runat="server" ID="cardtitle1">Post Title</h2>
              <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
              <a href="#" class="btn btn-primary">Read More &rarr;</a>
            </div>
            <div class="card-footer text-muted">
              Posted on January 1, 2017 by
              <a href="#">Start Bootstrap</a>
            </div>
          </div>

           Blog Post
          <div class="card mb-4">
            <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap">
            <div class="card-body">
              <h2 class="card-title" ID="cardtitle" runat="server">Post Title</h2>
              <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
              <a href="#" class="btn btn-primary">Read More &rarr;</a>
            </div>
            <div class="card-footer text-muted">
              Posted on January 1, 2017 by
              <a href="#">Start Bootstrap</a>
            </div>
          </div>

           Blog Post
          <div class="card mb-4">
            <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap">
            <div class="card-body">
              <h2 class="card-title">Post Title</h2>
              <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
              <a href="#" class="btn btn-primary">Read More &rarr;</a>
            </div>
            <div class="card-footer text-muted">
              Posted on January 1, 2017 by
              <a href="#">Start Bootstrap</a>
            </div>
          </div>-->

          <!-- Pagination -->
          <!--<ul class="pagination justify-content-center mb-4">
            <li class="page-item">
              <a class="page-link" href="#">&larr; Older</a>
            </li>
            <li class="page-item disabled">
              <a class="page-link" href="#">Newer &rarr;</a>
            </li>
          </ul>-->

        </div>

        <!-- Sidebar Widgets Column -->
        <div class="col-md-4">

          <!-- Search Widget -->
          <div class="card my-4">
            <h5 class="card-header">Search</h5>
            <div class="card-body">
              <div class="input-group">
                <asp:TextBox class="form-control" style="height:38px;" ID="search" runat="server" placeholder="Search for..."></asp:TextBox>
                <!--<input type="text" class="form-control" ID="search" placeholder="Search for...">-->
                <span class="input-group-btn">
                  <asp:Button class="btn btn-secondary" ID="search_button" runat="server" Text="Go!" OnClick="SearchButton"></asp:Button>
                </span>
              </div>
            </div>
          </div>

          <!-- Categories Widget -->
          <div class="card my-4">
            <h5 class="card-header">Categories</h5>
            <div class="card-body">
              <div class="row">
                <div class="col-lg-6">
                  <ul class="list-unstyled mb-0">
                    <li>
                      <!--<a href="#">Pending</a>-->
                      <!--<asp:HyperLink ID="PostData1" runat="server" NavigateUrl="#" OnClick="getpendingdata">Pending</asp:HyperLink>-->
                      <asp:Button ID="PostData11" CssClass="btn btn-link" runat="server" Text="Pending" OnClick="getpendingdata"></asp:Button>
                    </li>
                    <li>
                      <!--<a href="#">Approved</a>-->
                      <!--<asp:HyperLink ID="PostData2" runat="server" NavigateUrl="#" OnClick="getcompleteddata">Approved</asp:HyperLink>-->
                      <asp:Button ID="PostData22" CssClass="btn btn-link" runat="server" Text="Approved" OnClick="getcompleteddata"></asp:Button>
                    </li>
                    <li>
                      <a href="#"></a>
                    </li>
                  </ul>
                </div>
                <div class="col-lg-6">
                  <ul class="list-unstyled mb-0">
                    <li>
                      <a href="#"></a>
                    </li>
                    <li>
                      <!--<a href="#" onclick="getdata('Rejected')" runat="server">Rejected</a>-->
                      <!--<asp:HyperLink ID="PostData3" runat="server" NavigateUrl="#" OnClick="getrejecteddata">Rejected</asp:HyperLink>-->
                      <asp:Button ID="PostData33" CssClass="btn btn-link" runat="server" Text="Rejected" OnClick="getrejecteddata"></asp:Button>
                    </li>
                    <li>
                      <a href="#"></a>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>

          <!-- Side Widget
          <div class="card my-4">
            <h5 class="card-header">Side Widget</h5>
            <div class="card-body">
              You can put anything you want inside of these side widgets. They are easy to use, and feature the new Bootstrap 4 card containers!
            </div>
          </div>

        </div>-->

      </div>
      <!-- /.row -->

    </div>
    <!-- /.container -->

    <!-- Footer -->
    <footer class="py-5 bg-dark">
      <div class="container">
        <p class="m-0 text-center text-white"></p>
      </div>
      <!-- /.container -->
    </footer>

    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
</form>
<script type="text/javascript">
// <![CDATA[
// var theForm = document.forms['postticket'];
// if (!theForm) {
//     theForm = document.postticket;
// }
// function myFunction(eventTarget, eventArgument) {
//     if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
//       theForm.__EVENTTARGET.value = eventTarget;
//         theForm.__EVENTARGUMENT.value = eventArgument;
//         theForm.submit();
//     }
// }
// // function mya_mya(a){
// try {
//   var __original= __doPostBack;
//   __doPostBack = myFunction($(this).id(),$("#comment").val());
// }
// catch(err) {
//
// }
// var theForm = document.forms['postticket'];
// if (!theForm) {
//   theForm = document.postticket;
// }
// theForm.__EVENTTARGET.value = $("#comment").val();
$("#comment").change(function(){
    document.cookie = "comment="+ $("#comment").val();
  })
// $("#10002").click()
</script>

  </body>

</html>
