var bananaSplit = angular.module('bananaSplit', ['ngRoute']);

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
		    .success(function(data) {
		    	return data;
		    });

		return promise;
	}

	return {

		browseDirectory: function(directory) {
			return browser.browseDirectory(directory);
		},

		detectSplits: function(file) {
			var data = video.detectBlackFrames(file);

			debugger;

			var stderr = data.stderr.split('\r');

			var output = {
				blackdetect: [],
				duration: [],
				ffmpeg_output: stderr
			}

			// Go through each line
			for (let line of stderr) {
				line = line.trim();

				// If it's a blackdetect line, format it and add it to output
				if (line.indexOf('[blackdetect @') === 0) {
					output.blackdetect.push(BananaSplit.formatBlackDetectLine(line));
				}

				// If it's a line starting with duration, let's format the duration
				if (line.indexOf('Duration:') === 0) {
					output.duration = BananaSplit.formatDurationLine(line);
				}
			}

			output.blackdetect.forEach(function(black) {
				black.black_start = parseFloat(black.black_start);
				black.black_end = parseFloat(black.black_end);
				black.black_duration = parseFloat(black.black_duration);

				black.black_middle = black.black_start + (black.black_duration / 2);
			});

			return output;
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