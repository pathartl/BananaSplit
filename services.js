'use strict';

bananaSplit.factory('BananaSplit', function($http) {

	function UrlRequest(route) {

		var callback;

		if ( route.indexOf('?') >= 0 ) {
			callback = '&';
		} else {
			callback = '?';
		}

		callback += '_jsonp=JSON_CALLBACK';

		var promise = $http.jsonp( route + callback )
		    .success((data) => {
		    	return data;
		    });

		return promise;
	}

	return {

		browseDirectory: function(directory) {
			return browser.browseDirectory(directory);
		},

		detectSplits: function(file) {
			return video.detectBlackFrames(file);
		},

		splitVideo: function(segment) {
			video.createVideoSegment(segment.path, segment.start, segment.end, segment.output);
		},

		generateThumbnail: function(file, time) {
			return video.createFrameCapture(file, time);
		},

		getThumbnail: function(time) {
			return video.getFrameCapture(time);
		},

		formatBlackDetectLine: function(line) {
			return video.formatBlackDetectLine(line);
		},

		formatDurationLine: function(line) {
			return video.formatDurationLine(line);
		}

	}

});