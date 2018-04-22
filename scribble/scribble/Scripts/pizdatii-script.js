function pokajiBolishuiuKartinku(kartinka) {
	var date = new Date(kartinka.Created);

	bootbox.alert({
		message: '<div class="text-center"><h2>' + kartinka.Title + '</h2><hr />' +
			'<img class="rounded bg-white" style="width: 100%;" src="' + kartinka.DrawingBytes + '" />' +
			'<hr /> <p>' + kartinka.Description + '</p>' +
			'<hr /> <p>By ' + '<span class="text-warning">' + kartinka.DrawingCreator + '</span>' + '</p></div>' +
			'<p class="float-right text-white-50">' + date.toLocaleString() + '</p>',
		size: "large",
		backdrop: true
	});
}
