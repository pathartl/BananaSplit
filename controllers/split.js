'use strict';

bananaSplit.controller('BananaSplitSplitCtrl', function( $sce, $rootScope, $scope, BananaSplit, $routeParams ) {

	$scope.console = ['Running video through ffmpeg\'s black frame detection...'];

	$scope.gap = 2;

	$scope.currentSplit = 0;
	$scope.currentTime = '100%';
	$scope.splits = [];
	$scope.segments = [];
	$scope.processes = [];

	$scope.thumbnail = function(gapModifier) {
		if ( $scope.blackdetect != undefined ) {
			var file = $rootScope.currentVideo.path;
			var time = $scope.blackdetect[$scope.currentSplit].black_middle + ($scope.gap * gapModifier);

			return BananaSplit.getThumbnail(file, time);
		}
	}

	$scope.regenerateThumbnails = function() {
		if ($scope.processes.length > 0) {
			for (let process of $scope.processes) {
				if (typeof process.kill === 'function') {
					process.kill();
				}
			}
		}

		$scope.processes = [];

		$('.frame-thumbnail').each((i, thumbnail) => {
			if ($scope.blackdetect != undefined) {
				var modifier = parseInt($(thumbnail).attr('modifier'));

				var file = $rootScope.currentVideo.path;
				var time = $scope.blackdetect[$scope.currentSplit].black_middle + ($scope.gap * modifier);

				var thumbnailProcess = BananaSplit.generateThumbnail(file, time).then((process) => {
					$(thumbnail).attr('src', BananaSplit.getThumbnail(time));
				});

				$scope.processes.push(thumbnailProcess.childProcess);
			}
		});
	}

	$scope.setCurrentTime = function() {
		$scope.currentTime = ( $scope.blackdetect[$scope.currentSplit].black_middle / $scope.duration.in_seconds ) * 100;
		$scope.currentTime = $scope.currentTime + "%";

		$scope.regenerateThumbnails();
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

	BananaSplit.detectSplits($rootScope.currentVideo.path).then((data) => {
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

		$scope.console = output.ffmpeg_output;
		$scope.blackdetect = output.blackdetect;
		$scope.duration = output.duration;

		$scope.blackdetect.forEach(function(black) {
			black.black_start = parseFloat(black.black_start);
			black.black_end = parseFloat(black.black_end);
			black.black_duration = parseFloat(black.black_duration);

			black.black_middle = black.black_start + (black.black_duration / 2);
		});

		$scope.$apply(() => {
			$scope.setCurrentTime();
		});

		hideLoading();
	});

})