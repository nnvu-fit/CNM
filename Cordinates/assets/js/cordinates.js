var map;

function initMap() {
  map = new google.maps.Map(document.getElementById('map'), {
    center: {lat: -34.397, lng: 150.644},
    zoom: 8
  });
}

var LocationsList = [];

function getLocationList() {
  $('#GetAllLocations').last().remove();
  document.getElementById('Location-List').style.visibility  = 'visible';
  $.getJSON('Locations.json', function(data) {
    LocationsList = data;
    var source = $("#Location-template").html();
    var template = Handlebars.compile(source);
    var html = template(LocationsList);
    $('#Location-List').append(html);
  });
}


window.onload = function(e) {
  var windowHeight = $(window).height() - 65;
  var Main = document.getElementById("Main");
  var SideBar = document.getElementById("SideBar");

  Main.style.height = windowHeight.toString() + "px";
  SideBar.style.height = (windowHeight - 15).toString() + "px";

  Main.style.padding = "15px";
  SideBar.style.padding = "15px";
  initMap();
}
