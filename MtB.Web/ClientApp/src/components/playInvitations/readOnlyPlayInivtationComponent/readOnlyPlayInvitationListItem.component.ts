import { Component, Input, Output, EventEmitter } from "@angular/core";
import {PlayInvitation} from "../playInvitation.entity";

@Component({
    selector: 'readOnlyPlayInvitationListItem',
    templateUrl: "./readOnlyPlayInvitationListItem.component.html"
})
export class ReadOnlyPlayInvitationListItemComponent {
    @Input() playInvitation: PlayInvitation ;
    @Output() editRequested : EventEmitter<PlayInvitation>;
    @Output() removeRequested : EventEmitter<PlayInvitation>;
    constructor() {
        this.removeRequested = new EventEmitter < PlayInvitation>();
        this.editRequested = new EventEmitter<PlayInvitation>();
    }
    public edit() {
        this.editRequested.emit(this.playInvitation);
    }
}