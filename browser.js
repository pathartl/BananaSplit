'use strict'

const fs = require('fs');
const path = require('path');
const _ = require('lodash');

class BrowserService {
	constructor() {
		this.browseDirectory('');
		this.fs = fs;
	}

	humanReadableFilesize(bytes, decimals = 1) {
		var i = Math.floor( Math.log(bytes) / Math.log(1024) );
    	return ( bytes / Math.pow(1024, i) ).toFixed(2) * 1 + ' ' + ['B', 'kB', 'MB', 'GB', 'TB'][i];
	}

	isVideo(file) {
		return true;
	}

	browseDirectory(directory) {
		if (_.isUndefined(directory)) {
			directory = '';
		}

		if (directory == '' || directory.substring(directory.length - 1) != '/') {
			directory = directory + '/';
		}

		let files = fs.readdirSync(directory);

		let output = {
			directory: directory,
			files: []
		}

		for (let file of files) {
			try {
				let filePath = directory + file;

				let fileStats = fs.statSync(directory + '/' + file);

				let fileObject = {
					'path': fs.realpathSync(filePath),
					'name': file,
					'type': fileStats.isDirectory() ? 'dir' : 'file',
					'size': this.humanReadableFilesize(fileStats['size']),
					'is_video': this.isVideo(file)
				}

				output.files.push(fileObject);
			} catch(err) {

			}
		}

		console.log(output.files);

		return output;
	}

}
module.exports = BrowserService;