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
		$scope.createSegments();
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
		$scope.saveSplitInfo();
	}

	$scope.removeSplit = function(splitindex) {
		$scope.splits.splice(splitindex, 1);
		$scope.createSegments();
		$scope.saveSplitInfo();
	}

	$scope.saveSplitInfo = function() {
		var output = {
			blackdetect: $scope.blackdetect,
			duration: $scope.duration,
			ffmpeg_output: $scope.console,
			splits: $scope.splits
		}

		BananaSplit.saveSplits(output, $rootScope.currentVideo.path);
	}

	$scope.createSegments = function() {
		$scope.segments = [];

		if ( $scope.splits.length > 0 ) {
			var keyframes = [];
			keyframes[0] = 0;
			keyframes = keyframes.concat($scope.splits);
			keyframes.push($scope.duration.in_seconds);

			for (var i = 0; i < keyframes.length - 1; i++) {
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

	var splits = BananaSplit.loadSplits($rootScope.currentVideo.path);

	if (splits === false) {
		BananaSplit.detectSplits($rootScope.currentVideo.path).then((data) => {
			$scope.console = data.ffmpeg_output;
			$scope.blackdetect = data.blackdetect;
			$scope.duration = data.duration;

			$scope.$apply(() => {
				$scope.setCurrentTime();
			});

			hideLoading();
		});
	} else {
		$scope.console = splits.ffmpeg_output;
		$scope.blackdetect = splits.blackdetect;
		$scope.duration = splits.duration;

		if (typeof splits.splits != 'undefined') {
			$scope.splits = splits.splits;
		} else {
			$scope.splits = [];
		}

		$scope.setCurrentTime();
		hideLoading();
	}

})