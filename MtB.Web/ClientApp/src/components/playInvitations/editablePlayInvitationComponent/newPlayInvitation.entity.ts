import { RequestOptions, Headers, Http } from "@angular/http";
import {EditablePlayInvitation} from "./editablePlayInvitation.entity";
import {PlayInvitation} from "../playInvitation.entity";

export class NewPlayInivitation extends EditablePlayInvitation {

    constructor(baseUrl: string, http: Http) {
        super(baseUrl, http);
    }

    public  cancelEdit(playInvitations: PlayInvitation[]) {
        var index = playInvitations.findIndex(pi => pi == this);
        playInvitations.splice(index, 1); 
    }

    public save(onSuccess: Function) {
        let options = new RequestOptions();
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.post(this.baseUrl + "api/playInvitations", new PlayInvitation().copyFrom(this), options).subscribe(result => {
            onSuccess(result);
        });
    }
}
