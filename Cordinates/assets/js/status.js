var map;
var geocodeAddr = 'https://maps.googleapis.com/maps/api/geocode/json?address=';
var keyApi = 'AIzaSyBl6Hi5lkO6nGm5-J4M11jk-IUcF8TtDrc';

var config = {
    apiKey: "AIzaSyBzGZtw4pzqGcT5bISFeEiZDNfi1pCbDrE",
    authDomain: "barg-9f201.firebaseapp.com",
    databaseURL: "https://barg-9f201.firebaseio.com",
    projectId: "barg-9f201",
    storageBucket: "barg-9f201.appspot.com",
    messagingSenderId: "594787136476"
};

var LocationsList = [];
var Markers = [];
var MarkerInfos = [];

function getLocationList() {
  // $('#GetAllLocations').last().remove();
  document.getElementById('Location-List').style.visibility  = 'visible';
  firebase.initializeApp(config)
  firebase.database().ref('call/').on('value', function(snaps) {
    $('.Location-detail').last().remove();

    Object.keys(Markers).forEach(function(val) { Markers[val].setMap(null); });
    Object.keys(MarkerInfos).forEach(function(val) { MarkerInfos[val].close(); });

    LocationsList = [];
    Markers = [];
    MarkerInfos = [];

    LocationsList = JSON.parse(JSON.stringify(snaps.val()));

    Object.keys(LocationsList).forEach(function(val) {
      if (LocationsList[val].status == 0) {} else {
        pos = {lat: LocationsList[val].lat, lng: LocationsList[val].lng};
        Markers[val] = new google.maps.Marker({
          position: pos,
          title: val,
          map: map
        });
        MarkerInfos[val] = new google.maps.InfoWindow({
          content:  'ID: ' + val + '<br/>' +
                    'address: ' + LocationsList[val].addressFormated + '<br/>' +
                    'Status: ' +  (LocationsList[val].status == 0 ? 'unallocated <br/>' :
                                  LocationsList[val].status == 1 ? 'Successful positioning <br/>' :
                                  LocationsList[val].status == 2 ? 'received vehicle <br/>' : 'none <br/>') +
                    'Car Type: ' +  (LocationsList[val].TypeCar == 0 ? 'Standard <br/>' :
                                    LocationsList[val].TypeCar == 1 ? 'Prenium <br/>' : 'none <br/>')
        });
        Markers[val].addListener('click', function() {
          Object.keys(MarkerInfos).forEach(function(value1) {
            MarkerInfos[value1].close();
          });
          MarkerInfos[val].open(map, Markers[val]);
        });
      };
    });
    var source = $("#Location-template").html();
    var template = Handlebars.compile(source);
    var html = template(LocationsList);
    $('#Location-List').append(html);

    $.each($('.btn.btn-secondary.update'), function(key, val) {
      if (LocationsList[val.dataset.id].status != 0)
      {
        val.classList.remove('btn-secondary');
        val.classList.add('btn-success');
      }
    });

  });
}

$('#Location-List').on('click', '.mark', function() {
  var currentID = $(this).data('id');
  map.setCenter(Markers[currentID].position);
  map.setZoom(13);
})

$('#Location-List').on('click', '.detail', function() {
  var id = $(this).data('id');
  var currentDetail = [];
  currentDetail["id"] = id;
  currentDetail["status"] = (LocationsList[id].status == 0 ? 'unallocated' :
                LocationsList[id].status == 1 ? 'Successful positioning' :
                LocationsList[id].status == 2 ? 'received vehicle' : 'none');
  currentDetail["address"] = LocationsList[id].addressFormated;

  var top = 120;
  for (var ii = 0; ii < $('.btn.detail').length; ii++)
    if ($('.btn.detail')[ii].dataset.id == id) {
      top = 120 + ii*50;
    }
  popup = $('.popup')[0];
  popup.innerHTML = '<h3></h3><li style="list-style-type: none;">' + currentDetail["id"] + '</li>' +
                    '<h3></h3><li style="list-style-type: none;">' + currentDetail["status"] + '</li>' +
                    '<h3></h3><li style="list-style-type: none;">' + currentDetail["address"] + '</li>';
  popup.style.visibility = 'visible';
  popup.style.top = top + 'px';
})

function HidePopup() {
  $('.popup')[0].style.visibility = 'hidden';
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

function initMap() {
  map = new google.maps.Map(document.getElementById('map'), {
    center: {lat: 10.763755, lng: 106.684747},
    zoom: 8
  });
}
