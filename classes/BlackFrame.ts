export default class BlackFrame {
    Start: number;
    End: number;
    Duration: number;
    Middle: number;

    constructor(start: number, end: number, duration: number) {
        this.Start = start;
        this.End = end;
        this.Duration = duration;
        this.Middle = this.Start + (this.Duration / 2);
    }
}