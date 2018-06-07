import BlackFrame from "./BlackFrame";
import BlackFrameDuration from "./BlackFrameDuration";
import { List } from "linqts";

export default class BlackFrameDetection {
    BlackFrames: List<BlackFrame>;
    Duration: BlackFrameDuration;
    CommandOutput: string;
}