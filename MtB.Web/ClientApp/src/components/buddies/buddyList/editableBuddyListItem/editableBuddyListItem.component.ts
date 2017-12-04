import { Component, Input, Output, EventEmitter } from "@angular/core";
import{ EditableBuddy} from "./editableBuddy";


@Component({
    selector: 'editableBuddyListItem',
    templateUrl: "./editableBuddyListItem.component.html"
})
export class EditableBuddyListItemComponent {
    @Input() buddy: EditableBuddy ;
    @Output() buddyChanged : EventEmitter<string>;
    @Output() cancelEdit : EventEmitter<EditableBuddy>;

    constructor() {
        this.cancelEdit = new EventEmitter<EditableBuddy>();
        this.buddyChanged = new EventEmitter<string>();
    }

    public saveBuddy(buddy : EditableBuddy) {
        var self = this;
        var onSuccessfulSave = function() {
            self.buddyChanged.emit();
        }
         buddy.save(onSuccessfulSave);
    }


    public cancel(buddy: EditableBuddy) {
        this.cancelEdit.emit(buddy);
    }
}