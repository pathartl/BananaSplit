<?php

error_reporting(-1);

function detect_black_frames( $file ) {

	set_time_limit(65536);

	header('content-type: application/json; charset=utf-8');

	if ( isset( $_GET['_jsonp']) ) {
		$callback = $_GET['_jsonp'];
	} else {
		$callback = '';
	}
	
 	$file = escapeshellarg( $file );

 	$cmd = 'ffmpeg -i ' . $file . ' -vf blackdetect=d=0.1:pix_th=.1 -f rawvideo -y /dev/null 2>&1';

 	exec( $cmd, $stdout );

 	$stdout = implode("\r", $stdout);
 	$stdout = explode("\r", $stdout);
 	//$stdout = preg_split( "/(\\\\r|\\r) /", $stdout );
 	//$stdout = explode('\r', $stdout);

 	$output = array(
 		'ffmpeg_output' => $stdout,
 	);

 	$output['blackdetect'] = array();
 	$output['duration'] = array();

 	foreach ( $stdout as $line ) {

 		if ( strpos($line, '[blackdetect @') === 0 ) {
 			array_push($output['blackdetect'], format_blackdetect_line($line));
 		}

 		if ( strpos($line, '  Duration:') === 0 ) {
 			$duration = $line;
 			$duration = str_replace('  Duration: ', '', $duration);
 			$duration = explode(', ', $duration);

 			$output['duration']['full']  = $duration[0];

 			$time = explode(':', $duration[0]);
 			
 			$output['duration']['hour'] = $time[0];
 			$output['duration']['min'] = $time[1];
 			$output['duration']['seconds'] = $time[2];
 			$output['duration']['in_seconds'] = ($time[0] * 3600) + ($time[1] * 60) + $time[2];
 		}

 	}

	if ( $callback != '' ) echo $callback . '(';

 	echo json_encode( $output, JSON_PRETTY_PRINT );

	if ( $callback != '' ) echo ')';

 	//var_dump(explode('\r', $stdout));
}

function format_blackdetect_line( $line ) {

	$start = substr($line, 0, 26);

	$line = str_replace($start, '', $line);

	//$line = preg_replace('^\[blackdetect @.+\]\s+', '', $line);

	$blackdetect_data = explode(' ', $line);

	$new_blackdetect_data;

	foreach ( $blackdetect_data as $data_index => $data_item ) {
		$exploded_data = explode(':', $data_item);
		$new_blackdetect_data[$exploded_data[0]] = $exploded_data[1];
	}

	return $new_blackdetect_data;

}

function get_frame_capture( $file, $time, $output_name ) {

	if (file_exists('./' . $output_name . '.jpg')) {
		unlink('./' . $output_name . '.jpg');
	}

	$cmd = 'ffmpeg -ss ' . $time . ' -i ' . escapeshellarg($file) . ' -an -loglevel -8 -vframes 1 -q:v 2 -f image2pipe -';

	header("Content-Type: image/jpg");

	passthru($cmd);

}

function extract_segment($file, $start, $end, $output_filename) {

	header('content-type: application/json; charset=utf-8');

	if ( isset( $_GET['_jsonp']) ) {
		$callback = $_GET['_jsonp'];
	} else {
		$callback = '';
	}

	if ( isset( $_GET['_jsonp']) ) {
		$callback = $_GET['_jsonp'];
	} else {
		$callback = '';
	}

	$path = dirname($file);

	$cmd = 'ffmpeg -ss ' . $start . ' -i ' . escapeshellarg($file) . ' -t ' . ($end - $start) . ' -acodec copy -vcodec libx264 -y ' . escapeshellarg($path . '/' . $output_filename) . ' 2>&1';

	exec( $cmd, $output );

	if ( $callback != '' ) echo $callback . '(';

 	echo json_encode( $output, JSON_PRETTY_PRINT );

	if ( $callback != '' ) echo ')';

	//echo '{}';

}

if ( isset($_GET['function']) ) {

	$function = $_GET['function'];
 	$file = $_GET['f'];

 	if ( $function == 'detect' ) {
 		detect_black_frames( $file );
 	} else if ( $function == 'thumbnail' ) {

 		$output_name = $_GET['output'];

 		get_frame_capture( $_GET['f'], $_GET['time'], $output_name );
 	} else if ( $function == 'split' ) {
 		$start = $_GET['start'];
 		$end = $_GET['end'];
 		$output_filename = $_GET['output'];

 		extract_segment($file, $start, $end, $output_filename);
 	}

 	

}