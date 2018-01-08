var User = [];

$('#Login-SignIn').on('click', function() {
  User = [];
  User['email'] = $('#Login-InputEmail1')[0].value;
  User['password'] = $('#Login-InputPassword1')[0].value;
  console.log(User);

})

$('#Register-SignUp').on('click', function() {
  alert('Register Sign up');
})

$('#Register-form').on('click', '#SignIn', function() {
  $('.Register-template').last().remove();
  $('.login-template').last().remove();
  var source = $('#Login-Script').html();
  var template = Handlebars.compile(source);
  $('#login-form').append(template);
})

$('#login-form').on('click', '#SignUp', function() {
  $('.Register-template').last().remove();
  $('.login-template').last().remove();
  var source = $('#Register-Script').html();
  var template = Handlebars.compile(source);
  $('#Register-form').append(template);
})

getNotification = function() {
  alert("Get Notification");
  getNotification();
}

window.onload = function() {
  var source = $('#Login-Script').html();
  var template = Handlebars.compile(source);
  $('#login-form').append(template);
}
