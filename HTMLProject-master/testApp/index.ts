var textarea = <HTMLTextAreaElement> document.getElementById("textarea");
var generatedText = <HTMLElement> document.getElementById("generatedText");
class onClickEvent{
    onUpdateClick(){
        var textFromTextarea: string =  textarea.value; 
        generatedText.innerHTML += textFromTextarea;
        textarea.value = "";

    }
    onBlueButtonClick(){
        document.body.style.backgroundColor = "blue";
    }
    onRedButtonClick(){
        document.body.style.backgroundColor = "red";
    }
    onYellowButtonClick(){
        document.body.style.backgroundColor = "yellow";
    }
}
window.onload = () => {
    var updateButton = <HTMLButtonElement> document.getElementById("updateText");
    var blueButton = <HTMLButtonElement> document.getElementById("blueButton");
    var redButton = <HTMLButtonElement> document.getElementById("redButton");
    var yellowButton = <HTMLButtonElement> document.getElementById("yellowButton");
    var obj = new onClickEvent();
    updateButton.onclick = function(){
        obj.onUpdateClick();
    }
    blueButton.onclick = function(){
        obj.onBlueButtonClick();
    }
    redButton.onclick = function(){
        obj.onRedButtonClick();
    }
    yellowButton.onclick = function(){
        obj.onYellowButtonClick();
    }
}
