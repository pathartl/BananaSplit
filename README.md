# Banana Split

Banana Split is an application built in Angular, Bootstrap, and Electron that can be used to split video files based on ffmpeg's black frame detection feature.

## Installation

To install Banana Split, simply extract the zip file to a location of your choosing. Those familiar with Node can clone the repo and run `npm install`.

## Screen Shots

![File Browser](https://cldup.com/CDo6Rq8b01.png "The file browser")
![Spliting Interface](https://cldup.com/nA7SAjPnCi.png "The main splitting interface")
![Spliting Interface With Splits](https://cldup.com/JiwElYOEG9.png "Naming segments of the video")
![Queue](https://cldup.com/WNQ2OYYqCX.png "Queue with a segment being processed")

## Known Limitations

 - AVI doesn't play well with ffmpeg's video splitting, thus the video is automatically encoded to h.264 using libx264
 - Splitting AVI's may cause a weird starting time for audio/video. This is a limitation of AVI in general.
 - No errors are thrown for permission issues. Make sure you can write to the same folder as the source video.

### Version
2.0.0

### Tech

Banana Split uses a number of open source projects to work properly:

* [AngularJS](https://angularjs.org/) - HTML enhanced for web apps!
* [ffmpeg](https://www.ffmpeg.org/) - A complete, cross-platform solution to record, convert and stream audio and video.
* [Twitter Bootstrap](http://getbootstrap.com/) - great UI boilerplate for modern web apps
* [Electron](http://electron.atom.io/) - Because hybrid apps rock

### Changelog

#### 2.0.0

- Complete rewrite of the backend, now built in Electron!
- Support of Windows, Mac, Linux
- Made more sections of the app asynchronous
- Fixed some issues with the file browser

#### 1.1.0

- Added Windows compatibility
- Fixed a few UX/interface bugs
- Allowed the queue to stay opened but hidden when using the app
- Removed the need to write thumbnails to disk

#### 1.0.0

- Initial Release!

### License

MIT
