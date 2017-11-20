var map;

function initMap() {
  map = new google.maps.Map(document.getElementById('map'), {
    center: {lat: -34.397, lng: 150.644},
    zoom: 8
  });
}

var LocationsList = [];
var currentLocation;
var currentMarker;
var currentInfo;

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

$('#Location-List').on('click', '.mark', function() {
  var id = $(this).data('id');
  $.each(LocationsList, function(key, value) {
    if (value.id == id) {
      currentLocation = value;
    };
  });
  if (currentLocation) {
    if (currentLocation.status == 0) {
      alert("error");
    } else {
      var pos = {lat: currentLocation.lat, lng: currentLocation.lng};
      currentMarker = new google.maps.Marker({
        position: pos,
        title: currentLocation.name,
        map: map
      });
      currentInfo = new google.maps.InfoWindow({
        content: 'name: ' + currentLocation.name + '<br/>' + 'address: ' + currentLocation.addressFormated
      })
      map.setCenter(pos);
      map.setZoom(13);
      currentMarker.addListener('click', function() {
        currentInfo.open(map, currentMarker);
      })
    };
  };
})

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
