var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net",
	".net", "css", "wordpress", "xaml", "js", "http", "web",
	"asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript",
	"js", "cms", "html", "javascript", "http", "http", "CMS"];


generateTagCloud(tags, 16, 42);

function generateTagCloud(arrayOfTags, minFontSize, maxFontSize) {
	var tagOccurences = new Array();
	var	tagNames = new Array();
	var cloud = '';
	var mostOccurences = 0;
	var fontsizeValue = 0;
	uniqueTags = 0;

	//counting the occurrences of tags in the given array
	arrayOfTags.forEach(function (tag) {
		if (tagOccurences[tag]) {
			tagOccurences[tag]++;
		}
		else {
			tagOccurences[tag] = 1;
			tagNames[uniqueTags++] = tag;
		}
	});
	//find the highest amount of tag occurrences in the form of a number
	tagNames.forEach(function (tag) {
		if (tagOccurences[tag] > mostOccurences) {
			mostOccurences = tagOccurences[tag];
		}
	});
	//get the font-size interval needed to vary sizes
	fontsizeValue = (maxFontSize / mostOccurences);
	//set the size of the current tag by multiplying the interval by the amount of times the tag is used.
	tagNames.forEach(function (r) {
		//set the size, if it is smaller than the minimum font-size, it is the minimum font-size.
		var fontSize = (Math.round(fontsizeValue * tagOccurences[r]) > minFontSize) ? Math.round(fontsizeValue * tagOccurences[r]) : minFontSize;
		cloud += "<span style='font-size:" + fontSize + "px; " + "margin-right:15px" + "'>" + r + "</span>";
	});

	document.getElementById('tagCloud').innerHTML = cloud;
}