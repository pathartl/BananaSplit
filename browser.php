<?php

	function human_filesize($bytes, $decimals = 1) {
	    $size = array('B','KB','MB','GB','TB','PB','EB','ZB','YB');
	    $factor = floor((strlen($bytes) - 1) / 3);
	    return sprintf("%.{$decimals}f", $bytes / pow(1024, $factor)) . ' ' . @$size[$factor];
	}

	$supported_filetypes = array(
		'mkv',
		'mp4',
		'mov',
		'avi',
		'ts',
	);

	header('content-type: application/json; charset=utf-8');

	error_reporting(0);
	ini_set('display_errors', 0);

	if ( isset( $_GET['_jsonp']) ) {
		$callback = $_GET['_jsonp'];
	} else {
		$callback = '';
	}

	if ( isset( $_GET['d'] ) ) {
		$current_directory = $_GET['d'];
	} else {
		$current_directory = '';
	}

	if ( $current_directory == '' || substr($current_directory, strlen($current_directory) - 1) != '/' ) {
		$current_directory = $current_directory . '/';
	}

	$directory_list = scandir( $current_directory );

	$file_list = [];
	$file_list['files'] = [];

	$file_list['directory'] = $current_directory;

	foreach ( $directory_list as $file ) {
		$file_obj = [];

		$filepath = $current_directory . $file;

		$file_obj['path'] = realpath($filepath);
		$file_obj['name'] = $file;
		$file_obj['type'] = filetype( $filepath );
		$file_obj['size'] = human_filesize(filesize( $filepath ));
		$file_obj['is_video'] = false;

		if ( $file_obj['type'] == false ) {
			$file_obj['type'] = 'dir';
		}

		if ( $file_obj['path'] == false ) {
			$file_obj['path'] = realpath($current_directory) . $file;
		}

		foreach ( $supported_filetypes as $filetype ) {
			$extlen = strlen( $filetype ) + 1;
			if ( substr_compare( $file_obj['name'], '.' . $filetype, -1 * $extlen, $extlen ) === 0 ) {
				$file_obj['is_video'] = true;
			}
		}

		array_push( $file_list['files'], $file_obj );
	}

	if ( $callback != '' ) echo $callback . '(';

	echo json_encode( $file_list, JSON_PRETTY_PRINT );

	if ( $callback != '' ) echo ')';
?>