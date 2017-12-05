import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { BuddyList } from "./components/buddies/buddyList/buddyList.component";
import { BuddyListItemComponent} from "./components/buddies/buddyList/buddyListItem/buddyListItem.component";
import { EditableBuddyListItemComponent } from "./components/buddies/buddyList/editableBuddyListItem/editableBuddyListItem.component";
import { PlayInvitationComponent } from "./components/playInvitations/list/playInvitations.component";
import { ReadOnlyPlayInvitationListItemComponent } from "./components/playInvitations/readOnly/readOnlyPlayInvitationListItem.component";
import { EditablePlayInvitationListItemComponent } from "./components/playInvitations/editable/editablePlayInvitationListItem.component";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        PlayInvitationComponent,
        BuddyListItemComponent,
        EditableBuddyListItemComponent,
        BuddyList,
        ReadOnlyPlayInvitationListItemComponent,
        EditablePlayInvitationListItemComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: PlayInvitationComponent },
            { path: 'listBuddies', component: BuddyList },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
