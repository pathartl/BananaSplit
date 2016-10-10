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

	$scope.$watch('currentDirectory', () => {
		$scope.browseDirectory();
	});

})