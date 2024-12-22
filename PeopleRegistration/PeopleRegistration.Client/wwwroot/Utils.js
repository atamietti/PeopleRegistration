function switchTheme() {

    const newTheme = document.body.dataset.bsTheme === "dark" ? "light" : "dark";

    document.body.dataset.bsTheme = newTheme;
    localStorage.setItem('theme', newTheme);
}

function loadTheme() {
    const savedTheme = localStorage.getItem('theme');

    if (savedTheme) {

        document.body.dataset.bsTheme = savedTheme;
        document.getElementById('flexSwitchCheckChecked').checked = savedTheme === "dark";
    }

  //return  document.getElementById('flexSwitchCheckChecked').checked;
}

window.onload = loadTheme;


document.addEventListener('DOMContentLoaded', function () {
    const themeSwitch = document.getElementById('flexSwitchCheckChecked');
    if (themeSwitch) {
        themeSwitch.addEventListener('change', switchTheme);
    }
});  

function focusById(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}