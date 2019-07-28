import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Person } from '../models/person';
import { LifeEvent } from '../models/lifeevent';
import { LifeEventService } from '../services/lifeevent.service';
import { PersonService } from '../services/person.service';
import { CommonUtils } from '../common/common.utils';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lifeevent',
  templateUrl: './lifeevent.component.html'
})
export class LifeEventEditComponent {
  private id: number;
  private personid: number;
  private lifeevent: LifeEvent;
  private show_alert: boolean = false;
  private show_ok: boolean = false;
  private messages: string;
  private subscription: Subscription;
  

  constructor(http: HttpClient, private activateRoute: ActivatedRoute, private dataService: LifeEventService, private personService: PersonService, private router: Router) {
    this.subscription = activateRoute.params.subscribe(
      params => {
        if (this.router.url.indexOf("lifeevent-create")>-1) {
          this.personid = params['id'];
          this.lifeevent = new LifeEvent();
          this.lifeevent.personid = this.personid;
          this.personService.getPerson(this.personid).subscribe((data: any) => {
            this.lifeevent.personfullname = data.person.name+' '+data.person.surname;
          });
        } else {
          this.id = params['id'];
          this.dataService.getLifeEvent(this.id).subscribe((data: any) => {
            this.lifeevent = data.lifeevent;
            this.personid = data.lifeevent.personId;
          });
        }
      }
    );
  }
  
  save() {
    if (this.router.url.toString().indexOf('lifeevent-create')>-1) {
      this.dataService.createLifeEvent(this.lifeevent).subscribe((data: any) => {
        this.show_alert = data.messages.filter(m => m.type == 1).length > 0;
        if (this.show_alert) { this.messages = CommonUtils.getErorrMessagesText(data.messages); }
        this.show_ok = !this.show_alert;
      });
    } else {
      this.dataService.updateLifeEvent(this.lifeevent).subscribe((data: any) => {
        this.show_alert = data.messages.filter(m => m.type == 1).length > 0;
        if (this.show_alert) { this.messages = CommonUtils.getErorrMessagesText(data.messages); }
        this.show_ok = !this.show_alert;
      });
    }
  }
  changed() {
    this.show_alert = false;
    this.show_ok = false;
  }
  delete() {
    this.dataService.deleteLifeEvent(this.lifeevent.id).subscribe((data: any) => {
      this.show_alert = data.messages.filter(m => m.type == 1).length > 0;
      if (this.show_alert) { this.messages = CommonUtils.getErorrMessagesText(data.messages); }
      else { this.router.navigate(['/person', this.personid]); }
      
    });
  }
  goPerson() {
    this.router.navigate(['/person', this.personid]); 
  }
}

