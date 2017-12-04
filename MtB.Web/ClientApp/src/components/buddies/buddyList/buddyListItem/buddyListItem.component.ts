import { Component, Input, Output, EventEmitter } from "@angular/core";
import{ Buddy} from "../../buddy";

@Component({
    selector: 'buddyListItem',
    templateUrl: "./buddyListItem.component.html"
})
export class BuddyListItemComponent {
    @Input() buddy: Buddy ;
    @Output() editRequested : EventEmitter<Buddy>;
    @Output() removeRequested : EventEmitter<Buddy>;
    constructor() {
        this.removeRequested = new EventEmitter < Buddy>();
        this.editRequested = new EventEmitter<Buddy>();
    }
    public edit() {
        this.editRequested.emit(this.buddy);
    }
}