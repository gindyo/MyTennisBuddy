import  {NgModule} from '@angular/core'
import { Buddy } from "./buddy";
import { HttpModule } from "@angular/http";
import {EditableBuddy} from "./buddyList/editableBuddyListItem/editableBuddy";
import {NewBuddy} from "./buddyList/editableBuddyListItem/newBuddy";
import {EditableBuddyListItemComponent} from "./buddyList/editableBuddyListItem/editableBuddyListItem.component"
import {BuddyListItemComponent} from "./buddyList/buddyListItem/buddyListItem.component"
import {BuddyList} from "./buddyList/buddyList.component";

@NgModule({
    declarations: [
        Buddy,
        EditableBuddy,
        NewBuddy,
        BuddyListItemComponent,
        EditableBuddyListItemComponent,
        BuddyList


    ],
    imports: [HttpModule],
    exports: [
        Buddy,
        EditableBuddy,
        NewBuddy,
        BuddyListItemComponent,
        EditableBuddyListItemComponent
    ]
})
export class BuddyModule { }
