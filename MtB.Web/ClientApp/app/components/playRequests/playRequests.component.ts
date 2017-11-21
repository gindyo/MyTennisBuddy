import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions} from '@angular/http';

@Component({
    selector: 'playRequests',
    templateUrl: './playRequests.component.html'
})
export class PlayRequests {
    baseUrl: string;
    http: Http;
    public playRequests: PlayRequest[];

    public createPlayRequest() {
        this.playRequests.push(new PlayRequest());
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        http.get(baseUrl + '/api/playRequests/all').subscribe(result => {
            this.playRequests = result.json() as PlayRequest[];
        }, error => console.error(error));
    }
    public createRequest(playRequest:PlayRequest) {
        playRequest.isNew = false; 
        let options = new RequestOptions()
        options.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.post(this.baseUrl + "/api/playRequests/new",  playRequest , options).subscribe(result => {

        })
    }
}

class PlayRequest {
    constructor() {
        this.isNew = true;
    }
    isNew: boolean;
    externalId: string;
    date: string;
    time: string;
    status: string
}
