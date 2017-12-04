export class PlayInvitation {
    public externalId: string;
    public date: string = "";
    public time: string = "";
    public status: string = "";

    public copyFrom(pi: PlayInvitation) {
        this.date = pi.date;
        this.externalId = pi.externalId ;
        this.status =pi.status;
        this.time = pi.time;
        return this;
    }
}