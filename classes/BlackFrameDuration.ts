export default class BlackFrame {
    Hours: number;
    Minutes: number;
    Seconds: number;
    TotalSeconds: number;

    constructor(hours: number, minutes: number, seconds: number) {
        this.Hours = hours;
        this.Minutes = minutes;
        this.Seconds = seconds;
        this.TotalSeconds = (hours * 3600) + (minutes * 60) + seconds;
    }
}