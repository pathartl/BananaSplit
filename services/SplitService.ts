import fs from "fs";
import path from "path";
import { List } from "linqts";
import BlackFrameDetectionService from "./BlackFrameDetectionService";
import BlackFrameDetection from "../classes/BlackFrameDetection";
import FFMPEGCommand from "../classes/FFMPEGCommand";

export default class SplitService {
    private _blackFrameService : BlackFrameDetectionService;

    constructor() {
        this._blackFrameService = new BlackFrameDetectionService();
    }

    DetectSplits(file) : Promise<BlackFrameDetection> {
        let data = this._blackFrameService.DetectBlackFrames(file).then((output) => {
            this.SaveSplits(output, file);

            return output;
        });

		return data;
    }

    SaveSplits(data: BlackFrameDetection, filename: string) : void {
        let json = JSON.stringify(data);

		fs.writeFileSync(filename + '.json', json, 'utf8');
    }

    LoadSplits(filename: string) : BlackFrameDetection {
		try {
            let fileData = fs.readFileSync(filename + '.json', 'utf8');
            
            let data = <BlackFrameDetection> JSON.parse(fileData);
            
            return data;
		} catch(err) {
            throw err;
		}
    }
    
    private CreateSplit(file: string, start: number, end: number, outputFile: string) : Promise<any> {
        let filePath = path.dirname(file);
        
        let command = new FFMPEGCommand();

        command.Parameters = new List<string>([
            `-ss ${start}`,
            `-i "${file}"`,
            `-t "${(end - start)}`,
            `-acodec copy`,
            `-vcodec libx264`,
            `-y`,
            `"${filePath}/${outputFile}"`
        ]);

        return command.Execute();
	}
}