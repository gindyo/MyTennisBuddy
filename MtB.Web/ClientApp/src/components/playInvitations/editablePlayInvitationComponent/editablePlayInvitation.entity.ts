import {PlayInvitation} from "../playInvitation.entity"
import {Http, RequestOptions, Headers} from "@angular/http";

export class EditablePlayInvitation extends  PlayInvitation{
    baseUrl: string;
    http: Http;
    public isEditable: boolean = true;

    constructor(baseUrl: string,http: Http) {
        super();
        this.http = http;
        this.baseUrl = baseUrl;
    }

   public  cancelEdit(playInvitations: PlayInvitation[]) {
        var index = playInvitations.findIndex(b => b == this);
       playInvitations.splice(index, 1, new PlayInvitation().copyFrom(this)); 
    }

    public save(onSuccess: Function) {
        let options = new RequestOptions();
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.put(this.baseUrl + "/api/playInvitations", new PlayInvitation().copyFrom(this), options).subscribe(result => {
            onSuccess();
        });
    }
    

}
