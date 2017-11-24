import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions} from '@angular/http';

@Component({
    selector: 'playInvitation',
    templateUrl: './playInvitations.component.html'
})
export class PlayInvitationComponent {
    baseUrl: string;
    http: Http;
    public playInvitation: PlayInvitation[];

    public createPlayInvitation() {
        this.playInvitation.push(new PlayInvitation());
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        http.get(baseUrl + '/api/playInvitations/').subscribe(result => {
            this.playInvitation = result.json() as PlayInvitation[];
        }, error => console.error(error));
    }
    public createInvitation(playInvitation:PlayInvitation) {
        playInvitation.isNew = false; 
        let options = new RequestOptions()
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.post(this.baseUrl + "/api/playInvitations/",  playInvitation , options).subscribe(result => {

        })
    }
}

class PlayInvitation {
    constructor() {
        this.isNew = true;
    }
    isNew: boolean;
    externalId: string;
    date: string;
    time: string;
    status: string
}
