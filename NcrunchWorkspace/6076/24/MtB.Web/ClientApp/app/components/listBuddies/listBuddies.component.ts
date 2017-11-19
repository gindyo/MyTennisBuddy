import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions} from '@angular/http';

@Component({
    selector: 'listBuddies',
    templateUrl: './listBuddies.component.html'
})
export class ListBuddies {
    baseUrl: string;
    http: Http;
    public buddies: Buddy[];
    public addBuddy() {
        this.buddies.push(new Buddy());
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        http.get(baseUrl + '/api/buddieslist/buddies').subscribe(result => {
            this.buddies = result.json() as Buddy[];
        }, error => console.error(error));
    }
    public saveBuddy(buddy:Buddy) {
        buddy.isNew = false; 
        buddy.position = 5;
        let options = new RequestOptions()
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.post(this.baseUrl + "/api/buddieslist/new",  buddy , options).subscribe(result => {

        })
    }
}

class Buddy {
    constructor() {
        this.isNew = true;
    }
    isNew: boolean;
    externalId: string;
    email: string;
    cellPhoneNumber: string;
    firstName: string;
    position: number;
}
