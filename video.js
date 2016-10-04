'use strict'

const fs = require('fs');
const path = require('path');
const _ = require('lodash');
const escapeshellarg = require('escapeshellarg');
const ffmpeg = require('@ffmpeg-installer/ffmpeg').path;
const spawnSync = require('child_process').spawnSync;
const util = require('util');
const fileType = require('file-type');

class VideoService {
	constructor() {

	}

	formatBlackDetectLine(line) {
		let start = line.substring(0, 25);

		line = line.replace(start, '');

		let blackdetectData = line.split(' ');

		let output = {};

		for (let dataItem of blackdetectData) {
			let explodedData = dataItem.split(':');

			if (!_.isUndefined(explodedData[1])) {
				output[explodedData[0]] = explodedData[1];
			}
		}

		return output;
	}

	generateArgs(args) {
		let formattedArgs = [];

		for (let arg of args) {
			formattedArgs = formattedArgs.concat(arg.split(' '));
		}

		return formattedArgs;
	}

	formatDurationLine(line) {
		let duration = line;
		duration = duration.replace('Duration: ', '');
		duration = duration.split(', ');

		let output = {
			full: duration[0].trim()
		}

		let time = duration[0].split(':');

		output.hour = time[0];
		output.min = time[1];
		output.seconds = time[2];
		output.in_seconds = (parseFloat(output.hour) * 3600) + (parseFloat(output.min) * 60) + parseFloat(output.seconds);

		return output;
	}

	detectBlackFrames(file) {

		let ffmpegArgs = [
			'-i',
			file,
			'-vf',
			'blackdetect=d=0.2:pix_th=.1',
			'-f',
			'null',
			'-',
			'-y'
		]

		let command = ffmpeg + ' ' + ffmpegArgs.join(' ');

		var outputTemp = '';

		var output = {
			blackdetect: [],
			duration: [],
			ffmpeg_output: ''
		}

		var detect = spawnSync(ffmpeg, ffmpegArgs);

		let stderr = detect.stderr.toString();

		// exec(command, [], {}, (error, stdout, stderr) => {
		// 	debugger;
		// 	// stdout stuff
		stderr = stderr.split('\r');

		output.ffmpeg_output = stderr;

		// Go through each line
		for (let line of stderr) {
			line = line.trim();

			// If it's a blackdetect line, format it and add it to output
			if (line.indexOf('[blackdetect @') === 0) {
				output.blackdetect.push(this.formatBlackDetectLine(line));
			}

			// If it's a line starting with duration, let's format the duration
			if (line.indexOf('Duration:') === 0) {
				output.duration = this.formatDurationLine(line);
			}
		}

		// 	debugger;
		// });

		return output;
	}

	getFrameCapture(file, time) {
		console.log('generating thumbnail');
		// let ffmpegArgs = this.generateArgs([
		// 	'-ss ' + time,
		// 	'-i ' + file,
		// 	'-an',
		// 	'-loglevel -8',
		// 	'-vframes 1',
		// 	'-c:v mjpeg',
		// 	'-q:v 2',
		// 	'pipe:0',
		// 	'thumbnail.jpg'
		// ]);

		let ffmpegArgs = [
			'-i',
			file,
			'-c:v',
			'mjpeg',
			'-ss',
			time,
			'-vframes',
			'1',
			'./thumbnail.jpg',
			'-y'
		]

		var frame = spawnSync(ffmpeg, ffmpegArgs);

		var frameData = fs.readFileSync('./thumbnail.jpg');

		var mimetype = fileType(frameData).mime;

		return util.format('data:%s;base64,%s', mimetype, frameData.toString('base64'));
	}

	createVideoSegment(file, start, end, outputFile) {
		let filePath = path.dirname(file);

		let ffmpegArgs = [
			'-ss', start,
			'-i', file,
			'-t', (end - start),
			'-acodec', 'copy',
			'-vcodec', 'libx264',
			'-y',
			filePath + '/' + outputFile,
		]

		spawnSync(ffmpeg, ffmpegArgs);
	}
}
module.exports = VideoService;