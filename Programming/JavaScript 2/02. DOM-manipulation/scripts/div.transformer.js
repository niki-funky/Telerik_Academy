var count = 5;

generateDivs(count);

function generateDivs(number) {
	var divItems = document.createDocumentFragment();

	for (var k = 0; k < number; k++) {
		var divItem = generateDiv();
		divItems.appendChild(divItem);
	}

	field.appendChild(divItems);
}

function generateDiv() {
	var newDivItem = document.createElement("div");
	newDivItem.className = 'discoDiv';
	newDivItem.style.width = 80 + 'px';
	newDivItem.style.height = 80 + 'px';
	newDivItem.style.backgroundColor = generateRandomColor();
	newDivItem.innerHTML = '<strong>I rotate</strong>';
	newDivItem.style.color = generateRandomColor();
	newDivItem.style.position = 'absolute';
	newDivItem.style.left = (500 / 2 - 40) + 'px';
	newDivItem.style.top = (500 / 2 - 40) + 'px';
	newDivItem.style.borderStyle = "solid";
	newDivItem.style.borderRadius = 10 + 'px';
	newDivItem.style.borderColor = generateRandomColor();
	newDivItem.style.borderWidth = 5 + 'px';

	return newDivItem;
}

var allDiscoDivs = document.querySelectorAll('div.discoDiv');
var angle = 0;
var diameter = 100;
var increase = Math.PI * 2 / allDiscoDivs.length;
var shapeParameter = 200;

function rotateDiv() {
	for (i = 0; i < 5; i++) {
		x = diameter * Math.cos(angle) + shapeParameter;
		y = diameter * Math.sin(angle) + shapeParameter;
		allDiscoDivs[i].style.left = x + 'px';
		allDiscoDivs[i].style.top = y + 'px';
		allDiscoDivs[i].style.webkitTransform =
			allDiscoDivs[i].style.MozTransform =
			allDiscoDivs[i].style.OTransform =
			allDiscoDivs[i].style.transform =
			'rotate(' + Math.atan2(y - shapeParameter, x - shapeParameter) + 'rad' + ')';
		angle += increase;
	}
	//increases visual speed of rotation
	angle += 0.1;

	setTimeout(rotateDiv, 100);
}

rotateDiv();