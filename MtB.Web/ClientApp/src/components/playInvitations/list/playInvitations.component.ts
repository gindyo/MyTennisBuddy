import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions} from '@angular/http';
import {PlayInvitation} from "../playInvitation.entity";
import {NewPlayInivitation} from "../editable/newPlayInvitation.entity";
import {EditablePlayInvitation} from "../editable/editablePlayInvitation.entity";

@Component({
    selector: 'playInvitation',
    templateUrl: './playInvitations.component.html'
})
export class PlayInvitationComponent {
    baseUrl: string;
    http: Http;
    public playInvitations: PlayInvitation[];

    public createPlayInvitation() {
        this.playInvitations.push(new NewPlayInivitation(this.baseUrl, this.http));
    }
    public onPlayInvitationChanged() {
        this.loadPlayInvitations();
    }
    public onRemoveRequested() {
        
    };
    public onCancelEdit(invitation: EditablePlayInvitation) {
        invitation.cancelEdit(this.playInvitations);
    }

    public onEditRequested(playInvitation : PlayInvitation) {
           var index = this.playInvitations.findIndex(b => b == playInvitation);
            this.playInvitations.splice(index, 1, new EditablePlayInvitation(this.baseUrl, this.http).copyFrom(playInvitation)); 
    }
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.loadPlayInvitations();
    }
    public loadPlayInvitations() {
        this.http.get(this.baseUrl + '/api/playInvitations/').subscribe(result => {
            this.playInvitations = result.json() as PlayInvitation[];
        }, error => console.error(error));
    }
   
}