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
			return UrlRequest('browser.php?d=' + directory);
		},

		detectSplits: function(file) {
			return UrlRequest('video.php?function=detect&f=' + file);
		},

		splitVideo: function(segment) {
			return UrlRequest('video.php?function=split&f=' + segment.path + '&start=' + segment.start + '&end=' + segment.end + '&output=' + segment.output);
		}

	}

});