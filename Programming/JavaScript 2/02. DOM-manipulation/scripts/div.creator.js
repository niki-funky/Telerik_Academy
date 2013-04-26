function generateRandomNumberInRange(startOfRange, endOfRange) {
	var randomNumber = 0;
	randomNumber += Math.round(Math.random() * (endOfRange - startOfRange + 1) + startOfRange) + 'px';

	return randomNumber;
}

function generateRandomColor() {
	var chars = '0123456789ABCDEF'.split('');
	var color = '#';
	for (var i = 0; i < 6; i++) {
		color += chars[Math.round(Math.random() * 15)];
	}
	return color;
}

function generateRandomDiv() {
	var divElement = document.createElement("div");
	divElement.style.width = generateRandomNumberInRange(20, 100);
	divElement.style.height = generateRandomNumberInRange(20, 100);
	divElement.style.backgroundColor = generateRandomColor();
	divElement.innerHTML = '<strong>div</strong>';
	divElement.style.color = generateRandomColor();
	divElement.style.position = 'absolute';
	divElement.style.left = generateRandomNumberInRange(5, 500);
	divElement.style.top = generateRandomNumberInRange(5, 500);
	divElement.style.borderStyle = "solid";
	divElement.style.borderRadius = generateRandomNumberInRange(1, 10);
	divElement.style.borderColor = generateRandomColor();
	divElement.style.borderWidth = generateRandomNumberInRange(1, 20);

	return divElement;
}

function createDivs(number) {
	"use strict";
	var playField = document.getElementById('playfield');
	var listOfDivs = document.createDocumentFragment();

	for (var i = 0; i < number; i++) {
		var newDiv = generateRandomDiv();
		listOfDivs.appendChild(newDiv);
	}

	playField.appendChild(listOfDivs);
}