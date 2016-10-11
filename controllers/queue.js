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

		for (let segment of $rootScope.queue) {
			if (segment.status != 'pending') {
				$scope.currentQueueIndex++;
			}
		}

		$rootScope.encodingSegment = $rootScope.queue[$scope.currentQueueIndex];
		$scope.segmentVideo();
	}

	$scope.segmentVideo = function() {
		$('.queue .segment[index="' + $scope.currentQueueIndex + '"]').addClass('info');
		$('.queue .segment[index="' + $scope.currentQueueIndex + '"] .fa-cog').show();
		$rootScope.encodingSegment.status = 'encoding';

		BananaSplit.splitVideo($rootScope.encodingSegment).then(() => {
			$('.queue .segment[index="' + $scope.currentQueueIndex + '"]').removeClass('info').addClass('success');
			$('.queue .segment[index="' + $scope.currentQueueIndex + '"] .fa-cog').hide();
			$('.queue .segment[index="' + $scope.currentQueueIndex + '"] .fa-check').show();
			$rootScope.encodingSegment.status = 'complete';

			if ( $scope.currentQueueIndex + 1 < $rootScope.queue.length ) {
				$scope.currentQueueIndex++;
				$rootScope.encodingSegment = $rootScope.queue[$scope.currentQueueIndex];

				$scope.saveQueue();

				$scope.segmentVideo();
			}
		});
	}

});