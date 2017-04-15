'use strict';

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

		for (let file of response.files) {
			if ( file.name.indexOf('.') != 0 ) {
				$rootScope.directoryList.files.push(file);
			}

			if ( file.name == '..' ) {
				$rootScope.directoryList.parentDirectory = file;
			}
		}
	}

	$scope.openFile = function( file ) {
		showLoading();
		$rootScope.currentVideo = file;
		$location.path('/split');
	}

	$scope.toggleAllSelections = function() {
		if ($scope.allSelected == true) {
			for (let file of $rootScope.directoryList.files) {
				if (file.is_video) {
					file.selectedInFileBrowser = true;
				}
			}
		} else {
			for (let file of $rootScope.directoryList.files) {
				if (file.is_video) {
					file.selectedInFileBrowser = false;
				}
			}
		}
	}

	$scope.detectSplitsFromSelected = function() {
		showLoading();

		var splitDetectQueue = [];

		for (let file of $rootScope.directoryList.files) {
			if (file.selectedInFileBrowser == true) {
				splitDetectQueue.push(file);
			}
		}

		$scope.splitDetectQueueIndex = 0;

		$scope.progressBar = $('.loading .progress-bar');

		// Poor man's queueing
		$scope.queueInterval = setInterval(function() {
			var file = splitDetectQueue[$scope.splitDetectQueueIndex];

			if (file.runningSplitsDetection != true && file.splitsDetected != true) {
				file.runningSplitsDetection = true;

				$scope.progressBar.css('width', (($scope.splitDetectQueueIndex / (splitDetectQueue.length - 1)) * 100) + '%');

				BananaSplit.detectSplits(file.path).then(() => {
					file.splitsDetected = true;

					let allSplitsDetected = true;

					splitDetectQueue.forEach((file) => {
						if (file.splitsDetected != true) {
							allSplitsDetected = false;
						}
					});

					if (allSplitsDetected) {
						hideLoading();

						clearInterval($scope.queueInterval);

						$scope.progressBar.css('width', '100%');

						setTimeout(function() {
							$scope.browseDirectory();
						}, 500);
					}

					$scope.splitDetectQueueIndex++;
				});
			}
		}, 500);

	}

	$scope.$watch('currentDirectory', () => {
		$scope.browseDirectory();
	});

})