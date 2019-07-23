import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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
import { PersonListComponent } from './person/persons.component';
import { PersonEditComponent } from './person/person.component';
import { PersonFullNameComponent } from './person/person-fullname.component';
import { LifeEventEditComponent } from './lifeevent/lifeevent.component';
import { LifeEventListComponent } from './lifeevent/lifeevents.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AlertModule } from 'ngx-bootstrap/alert';
import { FileUploadComponent } from './common/file-upload/file-upload.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PersonListComponent,
    PersonEditComponent,
    PersonFullNameComponent,
    LifeEventEditComponent,
    LifeEventListComponent,
    FileUploadComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'persons', component: PersonListComponent },
      { path: 'person/:id', component: PersonEditComponent },
      { path: 'person', component: PersonEditComponent },
      { path: 'lifeevents', component: LifeEventListComponent },
      { path: 'lifeevent/:id', component: LifeEventEditComponent },
      { path: 'lifeevent-create/:id', component: LifeEventEditComponent },
      { path: 'lifeevent', component: LifeEventEditComponent },
    ]),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    AlertModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [PersonService, LifeEventService, FileUploadService],
  bootstrap: [AppComponent]
})
export class AppModule { }
