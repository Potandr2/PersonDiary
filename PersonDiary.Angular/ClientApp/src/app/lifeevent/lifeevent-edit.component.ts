import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Person } from '../models/person';
import { LifeEvent } from '../models/lifeevent';
import { LifeEventService } from '../services/lifeevent.service';
import { CommonUtils } from '../common/common.utils';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lifeevent-edit',
  templateUrl: './lifeevent-edit.component.html'
})
export class LifeEventEditComponent {
  public id: number;
  public personid: number;
  public lifeevent: LifeEvent;
  public show_alert: boolean = false;
  public show_ok: boolean = false;
  public messages: string;
  private subscription: Subscription;
  

  constructor(http: HttpClient, private activateRoute: ActivatedRoute, private dataService: LifeEventService, private router: Router) {
    this.subscription = activateRoute.params.subscribe(
      params => {
        if (this.router.url.includes("lifeevent-create")) {
          this.personid = params['id'];
          this.lifeevent = new LifeEvent();
          this.lifeevent.personid = this.personid;
        } else {
          this.id = params['id'];
          this.dataService.getLifeEvent(this.id).subscribe((data: any) => {
            this.lifeevent = data.lifeevent;
          });
        }
      }
    );
  }
  
  save() {
    if (this.router.url.toString().includes('lifeevent-create')) {
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
}

