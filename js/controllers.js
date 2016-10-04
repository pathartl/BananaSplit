function showLoading() {
	$('.loading .modal').modal('show');
}

function hideLoading() {
	$('.loading .modal').modal('hide');
}

bananaSplit.controller('BananaSplitMainCtrl', function( $sce, $rootScope, $scope, BananaSplit, $routeParams, $location ) {

	if ( $rootScope.currentDirectory === undefined ) {
		$rootScope.currentDirectory = '/';
	}

	$scope.loadQueue = function() {
		$rootScope.queue = JSON.parse(localStorage.getItem('queue'));
	}

	$scope.saveQueue = function() {
		localStorage.setItem('queue', JSON.stringify($rootScope.queue));
	}

	$scope.loadQueue();

	if ( $rootScope.queue === undefined || $rootScope.queue === null ) {
		$rootScope.queue = [];
	}

	$scope.queueVisible = false;

	$scope.toggleQueue = function() {
		$('body, #queue').toggleClass('slide');
	}	

	$scope.browseDirectory = function() {

		var response = BananaSplit.browseDirectory($rootScope.currentDirectory);

		$rootScope.directoryList = {};
		$rootScope.directoryList.directory = response.directory;
		$rootScope.directoryList.files = [];

		response.files.forEach(function(file) {
			if ( file.name.indexOf('.') != 0 ) {
				$rootScope.directoryList.files.push(file);
			}

			if ( file.name == '..' ) {
				$rootScope.directoryList.parentDirectory = file;
			}
		});
	}

	$scope.openFile = function( file ) {
		showLoading();
		$rootScope.currentVideo = file;
		$location.path('/split');
	}

	$scope.$watch('currentDirectory', function() {
		$scope.browseDirectory();
	});

})

.controller('BananaSplitSplitCtrl', function( $sce, $rootScope, $scope, BananaSplit, $routeParams ) {

	$scope.console = ['Running video through ffmpeg\'s black frame detection...'];

	$scope.gap = 2;

	$scope.currentSplit = 0;
	$scope.currentTime = '100%';
	$scope.splits = [];
	$scope.segments = [];

	$scope.thumbnail = function(gapModifier) {
		if ( $scope.blackdetect != undefined ) {
			var file = $rootScope.currentVideo.path;
			var time = $scope.blackdetect[$scope.currentSplit].black_middle + ($scope.gap * gapModifier);

			return BananaSplit.getThumbnail(file, time);
		}
	}

	$scope.regenerateThumbnails = function() {
		showLoading();

		$('.frame-thumbnail').each(function() {
			if ($scope.blackdetect != undefined) {
				var modifier = parseInt($(this).attr('modifier'));

				var file = $rootScope.currentVideo.path;
				var time = $scope.blackdetect[$scope.currentSplit].black_middle + ($scope.gap * modifier);

				$(this).attr('src', BananaSplit.getThumbnail(file, time));
			}
		});

		hideLoading();
	}

	$scope.setCurrentTime = function() {
		$scope.currentTime = ( $scope.blackdetect[$scope.currentSplit].black_middle / $scope.duration.in_seconds ) * 100;
		$scope.currentTime = $scope.currentTime + "%";

		clearTimeout($scope.thumbnailGenTimeout);

		$scope.thumbnailGenTimeout = setTimeout(function() {
			$scope.regenerateThumbnails();
		}, 500);
	}

	$scope.nextSplit = function() {
		if ( $scope.currentSplit != $scope.blackdetect.length - 1 ) {
			$scope.currentSplit = $scope.currentSplit + 1;
			$scope.setCurrentTime();
		}
	}

	$scope.prevSplit = function() {
		if ( $scope.currentSplit != 0 ) {
			$scope.currentSplit = $scope.currentSplit - 1;
			$scope.setCurrentTime();
		}
	}

	$scope.gotoSplit = function(index) {
		$scope.currentSplit = index;
		$scope.setCurrentTime();
	}

	$scope.addSplit = function() {
		$scope.splits.push($scope.blackdetect[$scope.currentSplit].black_end);
		$scope.createSegments();
	}

	$scope.removeSplit = function(splitindex) {
		$scope.splits.splice(splitindex, 1);
		$scope.createSegments();
	}

	$scope.createSegments = function() {
		$scope.segments = [];

		if ( $scope.splits.length > 0 ) {
			var keyframes = [];
			keyframes[0] = 0;
			keyframes = keyframes.concat($scope.splits);
			keyframes.push($scope.duration.in_seconds);

			for ( var i = 0; i < keyframes.length - 1; i++ ) {
				var currentSegment = {
					start: keyframes[i],
					end: keyframes[i + 1],
					encoding: false
				}

				$scope.segments.push(currentSegment);
			}

		}
	}

	$scope.addSegmentToQueue = function(segment, index) {
		segment.name = $rootScope.currentVideo.name;
		segment.path = $rootScope.currentVideo.path;
		segment.status = 'pending';
		$rootScope.queue.push(segment);

		$scope.segments[index].inQueue = true;

		$scope.saveQueue();
	}

	var splits = BananaSplit.detectSplits($rootScope.currentVideo.path);

	$scope.console = splits.ffmpeg_output;
	$scope.blackdetect = splits.blackdetect;
	$scope.duration = splits.duration;

	$scope.blackdetect.forEach(function(black) {
		black.black_start = parseFloat(black.black_start);
		black.black_end = parseFloat(black.black_end);
		black.black_duration = parseFloat(black.black_duration);

		black.black_middle = black.black_start + (black.black_duration / 2);
	});

	$scope.setCurrentTime();

	console.log(splits);

})

.controller('BananaSplitQueueCtrl', function( $sce, $rootScope, $scope, BananaSplit, $routeParams ) {

	$scope.removeAllFromQueue = function() {
		$rootScope.queue = [];
		$scope.saveQueue();
	}

	$scope.removeFromQueue = function(index) {
		$rootScope.queue.splice(index, 1);
		$scope.saveQueue();
	}

	$scope.startQueue = function() {
		$scope.currentQueueIndex = 0;

		$rootScope.queue.forEach(function(segment) {
			if (segment.status != 'pending') {
				$scope.currentQueueIndex++;
			}
		});

		$rootScope.encodingSegment = $rootScope.queue[$scope.currentQueueIndex];
		$scope.segmentVideo();
	}

	$scope.segmentVideo = function() {
		$rootScope.encodingSegment.status = 'encoding';

		BananaSplit.splitVideo($rootScope.encodingSegment);

		$rootScope.encodingSegment.status = 'complete';

		if ( $scope.currentQueueIndex + 1 < $rootScope.queue.length ) {
			$scope.currentQueueIndex++;
			$rootScope.encodingSegment = $rootScope.queue[$scope.currentQueueIndex];

			$scope.saveQueue();

			$scope.segmentVideo();
		}
	}

});