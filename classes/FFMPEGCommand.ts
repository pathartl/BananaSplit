import { List } from "linqts";
import * as FFMPEG from "@ffmpeg-installer/ffmpeg";
import { exec } from "child-process-promise/lib";

export default class FFMPEGCommand {
    public Parameters : List<String>;
    public Output : String;

    public Execute() : Promise<any> {
        let command = FFMPEG.path + ' ' + this.Parameters.ToArray().join(' ');

        let process = exec(command).then((data) => {
            if (data.stdout != "") {
                this.Output = data.stdout;
            } else {
                this.Output = data.stderr;
            }
        });

        return process;
    }
}