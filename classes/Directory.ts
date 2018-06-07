import fs from "fs";
import { List } from "linqts";
import File from "../classes/File";

export default class Directory {
    Path: string;
    Files: List<File>;
    SubDirectories: List<Directory>;

    constructor(path) {
        this.Path = path;
    }

    IsDirectory() : boolean {
        return Directory.IsDirectory(this.Path);
    }

    static IsDirectory(path: string) : boolean {
        let fileStats = fs.statSync(path);

        return fileStats.isDirectory();
    }
}