// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var cssSelectorRight = anime({
  targets: '#cssSelectorRight',
  translateX: "9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorLeft = anime({
  targets: '#cssSelectorLeft',
  translateX: "-9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorBottomRight = anime({
  targets: '#cssSelectorBottomRight',
  translateX: "4em",
  translateY: "9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorBottomLeft = anime({
  targets: '#cssSelectorBottomLeft',
  translateX: "-4em",
  translateY: "9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorTopLeft = anime({
  targets: '#cssSelectorTopLeft',
  translateX: "-4em",
  translateY: "-9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorTopRight = anime({
  targets: '#cssSelectorTopRight',
  translateX: "4em",
  translateY: "-9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorBottom1 = anime({
    targets: '#cssSelectorBottom1',
    translateX: "1em",
    translateY: "9em",
    opacity: 1,
    easing: 'linear',
    delay: 1000,
    duration: 2000
  });

var cssSelectorBottom2 = anime({
  targets: '#cssSelectorBottom2',
  translateX: "-1em",
  translateY: "9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorTop1 = anime({
  targets: '#cssSelectorTop1',
  translateX: "-1em",
  translateY: "-9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});

var cssSelectorTop2 = anime({
  targets: '#cssSelectorTop2',
  translateX: "1em",
  translateY: "-9em",
  opacity: 1,
  easing: 'linear',
  delay: 1000,
  duration: 2000
});


// Loading from arrays

var imgs = ['https://via.placeholder.com/150',
'https://via.placeholder.com/150',            
'https://via.placeholder.com/300',
'https://via.placeholder.com/150',            
'https://via.placeholder.com/300',
'https://via.placeholder.com/150',            
'https://via.placeholder.com/300',
'https://via.placeholder.com/150',            
'https://via.placeholder.com/300',
'https://via.placeholder.com/150',            
'https://via.placeholder.com/300'
         ];

var text = [
'1',
'2',
'3',
'4',
'5',
'6',
'7',
'8',
'9',
'10'
];
  
var container = document.getElementsByClassName('imgDiv');
var container2 = document.getElementsByClassName('textDiv');

for(var i=0; i<container.length; i++) {
  var img = document.createElement('img');
  img.src = imgs[i];
  var h = document.createElement('span');
  var t = document.createTextNode(text[i]);
  container[i].appendChild(img);
  container2[i].appendChild(t);
}



