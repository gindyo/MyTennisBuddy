import {Buddy} from '../../buddy'
import {Http, RequestOptions, Headers} from "@angular/http";

export class EditableBuddy extends  Buddy{
    baseUrl: string;
    http: Http;
    public isEditable: boolean = true;

    constructor( buddy: Buddy, baseUrl: string,http: Http) {
        super();
        this.copyFrom(buddy);
        this.http = http;
        this.baseUrl = baseUrl;
    }

   public  cancelEdit(buddies: Buddy[]) {
        var index = buddies.findIndex(b => b == this);
        buddies.splice(index, 1, this.toBuddy()); 
    }

    public save(onSuccess: Function) {
        let options = new RequestOptions();
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.put(this.baseUrl + "/api/buddyList", this.toBuddy(), options).subscribe(result => {
            onSuccess();
        });
    }
    public toBuddy() {
        return new Buddy().copyFrom(this);
    }
}
