import BlackFrameDetection from "../classes/BlackFrameDetection";
import BlackFrameDuration from "../classes/BlackFrameDuration";
import BlackFrame from "../classes/BlackFrame";
import FFMPEGCommand from "../classes/FFMPEGCommand";
import { List } from "linqts";

export default class BlackFrameDetectionService {
    private static GetBlackFrameFromLine(line: string) : BlackFrame {
        let matches = line.match(/black_start:(\d+\.\d+) black_end:(\d+\.\d+) black_duration:(\d+\.\d+)/);

        if (matches.length == 4) {
            let frame = new BlackFrame(parseFloat(matches[1]), parseFloat(matches[2]), parseFloat(matches[3]));

            return frame;
        } else {
            throw "Line does not contain black frame detection data";
        }
    }

    private static GetDurationFromLine(line: string) : BlackFrameDuration {
        let matches = line.match(/Duration: (\d+):(\d+):(\d+\.\d+)/);

        if (matches.length == 5) {
            let duration = new BlackFrameDuration(parseFloat(matches[1]), parseFloat(matches[2]), parseFloat(matches[3]));

            return duration;
        } else {
            throw "Line does not contain black frame duration data";
        }
    }

    public DetectBlackFrames(file: string) : Promise<BlackFrameDetection> {
        let command = new FFMPEGCommand();

        command.Parameters = new List<String>([
            "-i",
            "\"" + file + "\"",
            "-vf",
            "blackdetect=d=0.1:pix_th=.1",
            "-f",
            "null",
            "-",
            "-y"
        ]);

        return command.Execute().then((data) => {
            let detection = this.ParseFFMPEGDetectionOutput(data);

            return new Promise<BlackFrameDetection>((resolve) => {
                resolve(detection);
            });
        });
    }

    private ParseFFMPEGDetectionOutput(data) : BlackFrameDetection {
        let stderr = data.stderr.split('\r');
        
        let output = new BlackFrameDetection();
        output.BlackFrames = new List<BlackFrame>();        
        output.CommandOutput = stderr;

		// Go through each line
		for (let line of stderr) {
            try {
                output.BlackFrames.Add(BlackFrameDetectionService.GetBlackFrameFromLine(line));
                output.Duration = BlackFrameDetectionService.GetDurationFromLine(line);
            } catch(ex) {
                // Do nothing
            }
		}

		return output;
    }
}