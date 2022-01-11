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
