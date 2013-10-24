// Rename the function to onButtonClick and the input parameters to inputEvent and inputArguments
// Rename the local variables to currentWindow, browser and isMozilla
// Use ' instead of " to declare string value

function onButtonClick(inputEvent, inputArguments) {
    var currentWindow = window;
    var browser = currentWindow.navigator.appCodeName;
    var isMozilla = browser == 'Mozilla';
    if (isMozilla) {
        alert('Yes');
    }
    else {
        alert('No');
    }
}