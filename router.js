'use strict';

bananaSplit.config(function($routeProvider, $locationProvider) {
	$routeProvider
		.when(
			"/",
				{
					controller: 'BananaSplitMainCtrl',
					templateUrl: 'partials/browser.html'
				}
		)
		.when(
			"/split/",
				{
					controller: 'BananaSplitSplitCtrl',
					templateUrl: 'partials/split.html'
				}
		)
		.when(
			"/queue/",
				{
					controller: 'BananaSplitQueueCtrl',
					templateUrl: 'partials/queue.html'
				}
		)
		.otherwise(
			{
				redirectTo: "/"
			}
		);

	//$locationProvider.html5Mode(true);
});
