function switchTheme(theme) {

    document.body.dataset.bsTheme = theme;
    return true;
}

function focusById(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}

