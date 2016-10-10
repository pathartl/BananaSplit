'use strict';

bananaSplit.controller('BananaSplitQueueCtrl', function( $sce, $rootScope, $scope, BananaSplit, $routeParams ) {

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