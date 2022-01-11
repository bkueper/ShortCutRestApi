var textarea = document.getElementById("textarea");
var generatedText = document.getElementById("generatedText");
var onClickEvent = /** @class */ (function () {
    function onClickEvent() {
    }
    onClickEvent.prototype.onUpdateClick = function () {
        var textFromTextarea = textarea.value;
        generatedText.innerHTML += textFromTextarea;
        textarea.value = "";
    };
    onClickEvent.prototype.onBlueButtonClick = function () {
        document.body.style.backgroundColor = "blue";
    };
    onClickEvent.prototype.onRedButtonClick = function () {
        document.body.style.backgroundColor = "red";
    };
    onClickEvent.prototype.onYellowButtonClick = function () {
        document.body.style.backgroundColor = "yellow";
    };
    return onClickEvent;
}());
window.onload = function () {
    var updateButton = document.getElementById("updateText");
    var blueButton = document.getElementById("blueButton");
    var redButton = document.getElementById("redButton");
    var yellowButton = document.getElementById("yellowButton");
    var obj = new onClickEvent();
    updateButton.onclick = function () {
        obj.onUpdateClick();
    };
    blueButton.onclick = function () {
        obj.onBlueButtonClick();
    };
    redButton.onclick = function () {
        obj.onRedButtonClick();
    };
    yellowButton.onclick = function () {
        obj.onYellowButtonClick();
    };
};
function myConcat(seperator) {
    var theArgs = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        theArgs[_i - 1] = arguments[_i];
    }
    var result = '';
    var i;
    for (i = 0; i < theArgs.length; i++) {
        if (i == theArgs.length - 1) {
            result += theArgs[i];
        }
        else {
            result += theArgs[i] + seperator;
        }
    }
    return result;
}
console.log(myConcat(",", "3", "4", "k"));