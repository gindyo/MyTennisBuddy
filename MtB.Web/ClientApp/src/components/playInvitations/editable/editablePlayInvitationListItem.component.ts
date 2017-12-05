import { Component, Input, Output, EventEmitter } from "@angular/core";
import {EditablePlayInvitation} from "./editablePlayInvitation.entity";


@Component({
    selector: 'editablePlayInvitationListItem',
    templateUrl: "./editablePlayInvitationListItem.component.html"
})
export class EditablePlayInvitationListItemComponent {
    @Input() playInvitation: EditablePlayInvitation ;
    @Output() playInvitationChanged : EventEmitter<string>;
    @Output() cancelEdit : EventEmitter<EditablePlayInvitation>;

    constructor() {
        this.cancelEdit = new EventEmitter<EditablePlayInvitation>();
        this.playInvitationChanged = new EventEmitter<string>();
    }

    public savePlayInvitation(playInvitation : EditablePlayInvitation) {
        var self = this;
        var onSuccessfulSave = function() {
            self.playInvitationChanged.emit();
        }
         playInvitation.save(onSuccessfulSave);
    }


    public cancel(playInvitation: EditablePlayInvitation) {
        this.cancelEdit.emit(playInvitation);
    }
}