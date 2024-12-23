function switchTheme(theme) {

    document.body.dataset.bsTheme = theme;
}

function focusById(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}

