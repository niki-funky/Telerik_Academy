function onClick(event, arguments) {
	var currentWindow = window;
	var browserName = currentWindow.navigator.appCodeName;
	var isMozilla = (browserName === "Mozilla");
	if (isMozilla) {
		alert("Yes");
	}
	else {
		alert("No");
	}
}
