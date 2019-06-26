import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PersonService } from './services/person.service';
import { LifeEventService } from './services/lifeevent.service';
import { PersonListComponent } from './person/person-list.component';
import { PersonEditComponent } from './person/person-edit.component';
import { LifeEventEditComponent } from './lifeevent/lifeevent-edit.component';
import { LifeEventListComponent } from './lifeevent/lifeevent.list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PersonListComponent,
    PersonEditComponent,
    LifeEventEditComponent,
    LifeEventListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'person-list', component: PersonListComponent },
      { path: 'person-edit/:id', component: PersonEditComponent },
      { path: 'lifeevent-edit/:id', component: LifeEventEditComponent },
      { path: 'lifeevent-list', component: LifeEventListComponent },
    ]),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [PersonService,LifeEventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
