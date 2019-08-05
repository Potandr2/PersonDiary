import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PersonService } from './services/person.service';
import { LifeEventService } from './services/lifeevent.service';
import { FileUploadService } from './services/fileupload.service';
import { PersonsComponent } from './person/persons.component';
import { PersonComponent } from './person/person.component';
import { PersonFullNameComponent } from './person/person-fullname.component';
import { LifeEventComponent } from './lifeevent/lifeevent.component';
import { LifeEventsComponent } from './lifeevent/lifeevents.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AlertModule } from 'ngx-bootstrap/alert';
import { FileUploadComponent } from './common/file-upload/file-upload.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PersonsComponent,
    PersonComponent,
    PersonFullNameComponent,
    LifeEventComponent,
    LifeEventsComponent,
    FileUploadComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'persons', component: PersonsComponent },
      { path: 'person/:id', component: PersonComponent },
      { path: 'person', component: PersonComponent },
      { path: 'lifeevents', component: LifeEventsComponent },
      { path: 'lifeevent/:id', component: LifeEventComponent },
      { path: 'lifeevent-create/:id', component: LifeEventComponent },
      { path: 'lifeevent', component: LifeEventComponent },
    ]),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    AlertModule.forRoot(),
    ModalModule.forRoot(),
    PaginationModule.forRoot()
  ],
  providers: [PersonService, LifeEventService, FileUploadService],
  bootstrap: [AppComponent]
})
export class AppModule { }
