import { Component, Inject } from '@angular/core';
import { Http} from '@angular/http';
import {Buddy} from '../buddy'
import { EditableBuddy} from "./editableBuddyListItem/editableBuddy"
import {NewBuddy} from "./editableBuddyListItem/newBuddy";


@Component({
    selector: 'listBuddies',
    templateUrl: './buddyList.component.html'
})
export class BuddyList {
    baseUrl: string;
    http: Http;
    public buddies: Buddy[];

    public addBuddy() {
        this.buddies.push(new NewBuddy( this.baseUrl, this.http));
    }

    public onCancelEdit (buddy:EditableBuddy) {
        buddy.cancelEdit(this.buddies);
    }
    public onBuddyChanged (buddy:EditableBuddy) {
        this.loadBuddyes();
    }
    public onEditRequested(buddy: Buddy) {
           var index = this.buddies.findIndex(b => b == buddy);
            this.buddies.splice(index, 1, new EditableBuddy(buddy, this.baseUrl, this.http)); 
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.loadBuddyes();
    }

    loadBuddyes() {
        this.http.get(this.baseUrl + '/api/buddyList').subscribe(result => {
            this.buddies = result.json() as Buddy[];
        }, error => console.error(error));
    }

}

