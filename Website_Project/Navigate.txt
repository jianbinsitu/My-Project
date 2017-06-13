function openNav(name) {
  document.getElementById(name).style.width = "250px";
  document.getElementById("main").style.marginLeft = "250px";
}

function closeNav(name) {
  document.getElementById(name).style.width = "0";
  document.getElementById("main").style.marginLeft= "0";
}

function goBack(name) {
  document.getElementById(name).style.width = "0";
  document.getElementById("main").style.marginLeft= "0";
}

var slideIndex = 1;
var n = slideIndex;
var timer;
var timer_is_on = 0;
startCount();

function plusSlides(n) {
  stopCount();
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  stopCount();
  showSlides(slideIndex = n);
}

function showSlides(n) {
  //alert('showslides('+ n +')\nslideIndex='+slideIndex);
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("dot");
  if (n==undefined){n = ++slideIndex}
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " active";

  timer = setTimeout(showSlides, 5000); // Change image every 5 seconds
}

function startCount() {
  if (!timer_is_on) {
    timer_is_on = 1;
    showSlides(slideIndex);
  }
}

function stopCount() {
  clearTimeout(timer);
  timer_is_on = 0;
}