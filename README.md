# Banana Split

Banana Split is an application built in Angular, Bootstrap, and PHP that can be used to split video files based on ffmpeg's black frame detection feature.

## Installation

In order to run Banana Split you need a web server running PHP. This server must contain the video files you wish to split. You will also need ffmpeg installed and in the PATH of the web server's user. Point your virtual host to the Banana Split directory and you should be able to access the app.

**The web server user must also have permissions to write to the directory the video file exists in.**

## Screen Shots

![File Browser](https://cldup.com/CDo6Rq8b01.png "The file browser")
![Spliting Interface](https://cldup.com/nA7SAjPnCi.png "The main splitting interface")
![Spliting Interface With Splits](https://cldup.com/JiwElYOEG9.png "Naming segments of the video")
![Queue](https://cldup.com/WNQ2OYYqCX.png "Queue with a segment being processed")

## Known Limitations

 - AVI doesn't play well with ffmpeg's video splitting, thus the video is automatically encoded to h.264 using libx264

### Version
1.0.0

### Tech

Banana Split uses a number of open source projects to work properly:

* [AngularJS](https://angularjs.org/) - HTML enhanced for web apps!
* [ffmpeg](https://www.ffmpeg.org/) - A complete, cross-platform solution to record, convert and stream audio and video.
* [Twitter Bootstrap](http://getbootstrap.com/) - great UI boilerplate for modern web apps

### API

The API for Banana Split works via GET parameters. There are four main API functions

#### Thumbnail Generation
`video.php?f=<absolute path to video>&time=<time in seconds>&output=<output image name>`

Returns: Image

#### Directory Listings
`browser.php?d=<full path to directory>`

Returns: JSONP containing the listing of the specified directory

#### Black Frame Detection
`video.php?function=detect&f=<full path to file>`

Returns: JSONP containing info about black frames

#### Video Splitting
`video.php?function=split&f=<full path to input file>&start=<start of segment in seconds>&end=<end of segment in seconds>&output_filename=<output video file name>`

Returns: Output of ffmpeg formatted in JSONP

### License

MIT
