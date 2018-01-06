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
var currentLocation;
var currentMarker;
var currentInfo;
var currentID;

var DriverList = [];
var DriverMarkers = [];
var DriverInfos = [];
var currentDriver;
var currentDriverMarker;
var currentDriverInfo;
var currentDriverID;

var DriverBarg;
var CallBarg;

function getLocationList() {
  // $('#GetAllLocations').last().remove();
  if (CallBarg) {
    document.getElementById('Location-List').style.visibility  = 'visible';
    document.getElementById('Driver-List').style.visibility  = 'hidden';
    var ButtonControl = $('.Button-control-list')[0];
    ButtonControl.innerHTML = '<button type="button" class="btn btn-primary" onclick="getDriverList()" id="GetAllDrivers" style="width: 100%; margin-left: 0; margin-right: 0;">\
                                Show driver list\
                               </button>';
  } else {
    document.getElementById('Location-List').style.visibility  = 'visible';
    firebase.initializeApp(config)
    CallBarg = firebase.database().ref('call/');
    CallBarg.on('value', function(snaps) {
      $('.Location-detail').last().remove();
      $('.Driver-List').last().remove();

      Object.keys(Markers).forEach(function(val) { Markers[val].setMap(null); });
      Object.keys(MarkerInfos).forEach(function(val) { MarkerInfos[val].close(); });

      LocationsList = [];
      Markers = [];
      MarkerInfos = [];

      LocationsList = JSON.parse(JSON.stringify(snaps.val()));

      if (currentID) {
        LocationsList[currentID] = currentLocation;
        Markers[currentID] = currentMarker;
        MarkerInfos[currentID] = currentInfo;
      }

      Object.keys(LocationsList).forEach(function(val) {
        if (LocationsList[val].status == 0) {} else {
          pos = {lat: LocationsList[val].lat, lng: LocationsList[val].lng};
          Markers[val] = new google.maps.Marker({
            position: pos,
            title: val,
            map: map
          });
          MarkerInfos[val] = new google.maps.InfoWindow({
            content: 'ID: ' + val + '<br/>' + 'address: ' + LocationsList[val].addressFormated +
                     '<br/><button type="button" class="btn btn-primary mark" data-id="' + val + '">Book this Car</button>'
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
    var ButtonControl = $('.Button-control-list')[0];
    ButtonControl.innerHTML = '<button type="button" class="btn btn-primary" onclick="getDriverList()" id="GetAllDrivers" style="width: 100%; margin-left: 0; margin-right: 0;">\
                                Show driver list\
                               </button>';
  }
}

function getDriverList() {
  document.getElementById('Driver-List').style.visibility  = 'visible';
  document.getElementById('Location-List').style.visibility  = 'hidden';
  var ButtonControl = $('.Button-control-list')[0];
  ButtonControl.innerHTML = '<button type="button" class="btn btn-primary" onclick="getLocationList()" id="GetAllDrivers" style="width: 100%; margin-left: 0; margin-right: 0;">\
                              Show Call list\
                             </button>';

  // fetch('http://localhost:56081/api/managerappone/finddriver', {
  //   method: 'put',
  //   body: {
  //     "lat": 10.7918069,
  //     "lng": 106.6988929,
  //     "typeCar": 0,
  //     "radius": 50000
  //   }
  // })
var jsonObject = {
        lat: 10.724199032203845,
        lng: 106.75121212188608,
        typeCar: 0,
        radius: 50000
    };

var places = 8,
    json = JSON.stringify(jsonObject, function(key, value) {
        // limit precision of floats
        if (typeof value === 'number') {
            return parseFloat(value.toFixed(places));
        }
        return value;
    });
    console.log(json);
  fetch('http://localhost:56081/api/managerappone/finddriver',
  {

      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      method: "PUT",
      body: json
  }).then(function(response){
    if (response.status == 200)
      response.json().then(function(data){
          $('.Location-detail').last().remove();
          $('.Driver-List').last().remove();

          Object.keys(Markers).forEach(function(val) { Markers[val].setMap(null); });
          Object.keys(MarkerInfos).forEach(function(val) { MarkerInfos[val].close(); });
          Markers = [];
          MarkerInfos = [];

          Object.keys(DriverMarkers).forEach(function(val) { DriverMarkers[val].setMap(null); });
          Object.keys(DriverInfos).forEach(function(val) { DriverInfos[val].close(); });
          DriverInfos = [];
          DriverList = [];
          DriverMarkers = [];

          DriverList = JSON.parse(JSON.stringify(data));
          console.log(DriverList);

          var source = $("#Drivers-template").html();
          var template = Handlebars.compile(source);
          var html = template(DriverList);
          $('#Driver-List').append(html);


      });
  });

  // if (DriverBarg) {} else {
  //   DriverBarg = firebase.database().ref('driver/');
  //   DriverBarg.on('value', function(snaps) {
  //     $('.Drivers-detail').last().remove();
  //
  //     Object.keys(DriverMarkers).forEach(function(val) { DriverMarkers[val].setMap(null); });
  //     Object.keys(DriverInfos).forEach(function(val) { DriverInfos[val].close(); });
  //
  //     DriverInfos = [];
  //     DriverMarkers = [];
  //     DriverList = JSON.parse(JSON.stringify(snaps.val()));
  //
  //     if (currentDriverID) {
  //       DriverList[currentDriverID] = currentDriver;
  //       DriverMarkers[currentDriverID] = currentDriverMarker;
  //       DriverInfos[currentID] = currentDriverInfo;
  //     }
  //
  //     Object.keys(LocationsList).forEach(function(val) {
  //       if (LocationsList[val].status == 0) {} else {
  //         pos = {lat: LocationsList[val].lat, lng: LocationsList[val].lng};
  //         Markers[val] = new google.maps.Marker({
  //           position: pos,
  //           title: val,
  //           map: map
  //         });
  //         MarkerInfos[val] = new google.maps.InfoWindow({
  //           content: 'ID: ' + val + '<br/>' + 'address: ' + LocationsList[val].addressFormated +
  //                    '<br/><button type="button" class="btn btn-primary mark" data-id="' + val + '">Book this Car</button>'
  //         });
  //         Markers[val].addListener('click', function() {
  //           Object.keys(MarkerInfos).forEach(function(value1) {
  //             MarkerInfos[value1].close();
  //           });
  //           MarkerInfos[val].open(map, Markers[val]);
  //         });
  //       };
  //     });
  //
  //     var source = $("#Drivers-template").html();
  //     var template = Handlebars.compile(source);
  //     var html = template(LocationsList);
  //     $('#Driver-List').append(html);
  //
  //     console.log(DriverList);
  //   });
  // }
}

$('#Location-List').on('click', '.mark', function() {
  currentID = $(this).data('id');
  currentLocation = LocationsList[currentID];
  if (currentLocation.status == 0) {
    fetch(geocodeAddr + currentLocation.address.replace(/ /g, "+") + '&key=' + keyApi, {
    }).then(function(response) {
      if (response.status == 200) {
        response.json().then(function(data) {
          if (data.status == "OK") {
            LocationsList[currentID].addressFormated = data.results[0].formatted_address;
            LocationsList[currentID].lat = data.results[0].geometry.location.lat;
            LocationsList[currentID].lng = data.results[0].geometry.location.lng;
            LocationsList[currentID].status = 1;
            currentLocation = LocationsList[currentID];

            var pos = {
              lat: currentLocation.lat,
              lng: currentLocation.lng
            };

            Markers[currentID] = new google.maps.Marker ({
              position: pos,
              title: currentID.toString(),
              map: map
            });
            MarkerInfos[currentID] = new google.maps.InfoWindow({
              content: 'ID: ' + currentID + '<br/>' + 'address: ' + LocationsList[currentID].addressFormated
            });
            Markers[currentID].addListener('click', function() {
              Object.keys(MarkerInfos).forEach(function(value1) {
                MarkerInfos[value1].close();
              });
              MarkerInfos[currentID].open(map, Markers[currentID]);
            });

            currentInfo = MarkerInfos[currentID];
            currentMarker = Markers[currentID];
            map.setCenter(Markers[currentID].position);
            map.setZoom(13);
          }
        });
      } else {
        throw new Error('Network response was not ok.');
      }
    });
  } else {
    currentInfo = MarkerInfos[currentID];
    currentMarker = Markers[currentID];
    map.setCenter(Markers[currentID].position);
    map.setZoom(13);
  }
})

$('#Location-List').on('click', '.update', function() {
  var id = $(this).data('id');
  if (id == currentID) {
    console.log('call/'+ currentID + '/');
    firebase.database().ref('call/'+ currentID + '/').set(currentLocation);
  }

  currentID = null;
  currentLocation = null;
  currentInfo = null;
  currentMarker = null;
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

function initMap() {
  map = new google.maps.Map(document.getElementById('map'), {
    center: {lat: 10.763755, lng: 106.684747},
    zoom: 8
  });

  map.addListener('click', function(e) {
    if (currentMarker) {
      currentMarker.setPosition(e.latLng);
      currentLocation.lat = e.latLng.lat();
      currentLocation.lng = e.latLng.lng();
      var Button;
      for (ii = 0; ii < $('.btn.update').length; ii++)
        if (($('.btn.update'))[ii].dataset.id == currentID) {
          Button = ($('.btn.update'))[ii];
        }
      Button.classList.remove('btn-secondary');
      Button.classList.add('btn-warning');
    };
  });
}
