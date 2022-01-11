window.onload = function () {
    document.getElementsByClassName("app")[0].style.height =
      window.innerHeight + "px";
  };
  //display nav
  document.getElementById("nav").onclick = function () {
    document.getElementsByClassName("nav_open")[0].style.left = "0px";
    document.getElementsByClassName("nav_open")[0].style.boxShadow =
      "30px 40px 100px 0px gray";
  };
  document.getElementById("close").onclick = function () {
    document.getElementsByClassName("nav_open")[0].style.left = "-80%";
    document.getElementsByClassName("nav_open")[0].style.boxShadow = "none";
  };
  
  // color _ mode
  document.getElementsByClassName("color_mode")[0].onclick = function () {
    if (this.checked == true) {
      document.getElementById("content").style.backgroundColor = "#282923";
      document.getElementsByClassName(
        "nav_open_content_header"
      )[0].style.backgroundColor = "#282923";
    } else {
      document.getElementById("content").style.backgroundColor = "whitesmoke";
      document.getElementsByClassName(
        "nav_open_content_header"
      )[0].style.backgroundColor = "whitesmoke";
    }
  };
  //number count
  document.getElementsByClassName("count")[0].onclick = function () {
    document.getElementsByClassName("display")[0].value =
      parseInt(document.getElementsByClassName("display")[0].value) + 1;
  };
  //Home button
  function homePage() {
    alert("add your own functionality");
  }
