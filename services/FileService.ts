import fs from "fs";
import { List } from "linqts";
import Directory from "../classes/Directory";
import File from "../classes/File";

export default class FileService {
    constructor() {
        this.BrowseDirectory("");
    }

    BrowseDirectory(directory: string = "") {
        if (directory === "" || directory.substring(directory.length - 1) != "/") {
            directory += "/";
        }

        let fsObjects = fs.readdirSync(directory);
        
        let directories = new List<Directory>();
        let files = new List<File>();

        for (let file of fsObjects) {
            if (File.IsFile(`${directory}/${file}`)) {
                files.Add(new File(directory, file));
            }

            if (Directory.IsDirectory(`${directory}/${file}`)) {
                directories.Add(new Directory(`${directory}/${file}`));
            }
        }

        let output = new Directory(directory);
        output.Files = files;
        output.SubDirectories = directories;

        return output;
    }
}