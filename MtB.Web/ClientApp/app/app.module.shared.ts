import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ListBuddies } from './components/listBuddies/listBuddies.component';
import { CounterComponent } from './components/counter/counter.component';
import { PlayRequests } from './components/playRequests/playRequests.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        PlayRequests,
        ListBuddies,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: PlayRequests },
            { path: 'counter', component: CounterComponent },
            { path: 'listBuddies', component: ListBuddies },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
