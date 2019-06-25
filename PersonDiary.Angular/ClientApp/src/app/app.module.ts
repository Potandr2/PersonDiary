import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PersonService } from './services/person.service';
import { LifeEventService } from './services/lifeevent.service';
import { PersonListComponent } from './person/person-list';
import { PersonEditComponent } from './person/person-edit';
//import { LifeEventListComponent } from './lifeevent/lifeevent-list';
import { LifeEventEditComponent } from './lifeevent/lifeevent-edit';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonListComponent,
    PersonEditComponent,
    //LifeEventListComponent,
    LifeEventEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'person-list', component: PersonListComponent },
      { path: 'person-edit/:id', component: PersonEditComponent },
      //{ path: 'lifeevent-list', component: LifeEventListComponent },
      { path: 'lifeevent-edit/:id', component: LifeEventEditComponent },
    ])
  ],
  providers: [PersonService,LifeEventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
