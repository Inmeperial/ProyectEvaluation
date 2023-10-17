const hamburger = document.querySelector('.hamburger');
const navMenu = document.querySelector('.nav-menu');

// eslint-disable-next-line no-unused-vars
function mobileMenu() {
  hamburger.classList.toggle('active');
  navMenu.classList.toggle('active');
}

const navLink = document.querySelectorAll('.nav-link');

function closeMenu() {
  hamburger.classList.remove('active');
  navMenu.classList.remove('active');
}

navLink.forEach((element) => element.addEventListener('click', closeMenu));
hamburger.addEventListener('click', mobileMenu);
