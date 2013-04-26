var newTextArea = document.getElementsByTagName('textarea')[0];

function changeFontColor() {
	var fontColor = document.getElementById('fontColor').value;

	newTextArea.style.color = fontColor;
}

function changeBackgroundColor() {
	var background = document.getElementById('backgroundColor').value;

	newTextArea.style.backgroundColor = background;
}