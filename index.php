<!DOCTYPE html>
<html lang="en" class="">
<head>
	<meta charset="UTF-8">
	<title>Banana Split</title>

	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">

	<script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

	<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.5/angular.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.0-beta.0/angular-route.min.js"></script>

	<script src="js/services.js"></script>
	<script src="js/controllers.js"></script>
	<script src="js/routing.js"></script>

	<style type="text/css">

		.progress {
			position: relative;
			overflow: visible;
		}

		.progress .tooltip {
			opacity: 1;
			top: -32px;
			transform: translateX(-50%);
		}

		.input-group {
			margin-bottom: 10px;
		}

		td {
			vertical-align: middle !important;
		}

		#queue {
			position: fixed;
			left: 100%;
			width: 100%;
			transition: 0.25s all;
			top: 0;
			bottom: 0;
		}

		#queue.slide {
			left: 0%;
			overflow-y: scroll;
		}

		body {
			position: relative;
			left: 0;
			transition: 0.25s all;
		}

		body.slide {
			left: -100%;
			overflow-y: hidden;
		}

	</style>
</head>
<body>
	<div ng-app="bananaSplit" ng-controller="BananaSplitMainCtrl" class="container">
		<div ng-view></div>
		<div id="queue" ng-include src='"partials/queue.html"' ng-controller="BananaSplitQueueCtrl"></div>
	</div>
</body>
</html>