import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions} from '@angular/http';

@Component({
    selector: 'playInvites',
    templateUrl: './playInvites.component.html'
})
export class PlayInvites {
    baseUrl: string;
    http: Http;
    public playInvites: PlayInvite[];

    public createPlayInvite() {
        this.playInvites.push(new PlayInvite());
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        http.get(baseUrl + '/api/playInvites/').subscribe(result => {
            this.playInvites = result.json() as PlayInvite[];
        }, error => console.error(error));
    }
    public createInvite(playInvite:PlayInvite) {
        playInvite.isNew = false; 
        let options = new RequestOptions()
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.post(this.baseUrl + "/api/playInvites/",  playInvite , options).subscribe(result => {

        })
    }
}

class PlayInvite {
    constructor() {
        this.isNew = true;
    }
    isNew: boolean;
    externalId: string;
    date: string;
    time: string;
    status: string
}
