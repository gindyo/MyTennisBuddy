import {EditableBuddy} from "./editableBuddy";
import {Buddy} from '../../buddy';
import { RequestOptions, Headers, Http } from "@angular/http";

export class NewBuddy extends EditableBuddy {

    constructor(baseUrl: string, http: Http) {
        super(new Buddy(), baseUrl, http);
    }

    public  cancelEdit(buddies: Buddy[]) {
        var index = buddies.findIndex(b => b == this);
        buddies.splice(index, 1); 
    }

    public save(onSuccess: Function) {
        this.position = 5;
        let options = new RequestOptions();
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.post(this.baseUrl + "/api/buddyList", this.toBuddy(), options).subscribe(result => {
            onSuccess(result);
        });
    }
}
