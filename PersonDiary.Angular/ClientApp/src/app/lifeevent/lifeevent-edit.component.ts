import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Person } from '../models/person';
import { LifeEvent } from '../models/lifeevent';
import { LifeEventService } from '../services/lifeevent.service';

@Component({
  selector: 'app-lifeevent-edit',
  templateUrl: './lifeevent-edit.component.html'
})
export class LifeEventEditComponent implements OnInit {
  public id: number;
  public lifeevent: LifeEvent;
  private subscription: Subscription;

  constructor(http: HttpClient, private activateRoute: ActivatedRoute, private dataService: LifeEventService) {
    this.subscription = activateRoute.params.subscribe(
      params => {
        this.id = params['id'];

        this.dataService.getLifeEvent(this.id).subscribe((data: any) => {
          this.lifeevent = data.lifeEvent;
        });
      }
    );

  }
  ngOnInit() {

  }
  save() {
    this.dataService.updateLifeEvent(this.lifeevent).subscribe((data: LifeEvent) => {});
  }
}

