import fs from "fs";

export default class File {
    Path: string;
    Name: string;
    Size: string;
    RealSize: number;

    constructor(directory: string, file: string) {
        let filePath = directory + file;
        let fileStats = fs.statSync(`${directory}/${file}`);

        this.Path = fs.realpathSync(filePath);
        this.Name = file;
        this.Size = File.GetHumanReadableFilesize(fileStats['size']);
        this.RealSize = fileStats['size'];
    }

    IsVideo() {
        return File.IsVideo(this.Name);
    }

    IsFile() {
        return File.IsFile(this.Path);
    }

    static GetHumanReadableFilesize(bytes: number, decimals: number = 1) : string {
        var i = Math.floor(Math.log(bytes) / Math.log(1024));

        return (bytes / Math.pow(1024, i)).toFixed(2) + " " + ["B", "KB", "MB", "GB", "TB"][i];
    }

    static IsVideo(file: string) : boolean {
        return /\.(mkv|mp4|avi|ts|divx|m4v)$/.test(file);
    }

    static IsFile(filepath: string) : boolean {
        let fileStats = fs.statSync(filepath);

        return fileStats.isFile();
    }
}