import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LifeEvent } from '../models/lifeevent';
import { LifeEventService } from '../services/lifeevent.service';


@Component({
  selector: 'app-lifeevents',
  templateUrl: './lifeevents.component.html'
})
export class LifeEventsComponent {
  public lifeevents: LifeEvent[];

  constructor(http: HttpClient, private dataService: LifeEventService) {

    this.dataService.getLifeEvents().subscribe((data: any) => {
      this.lifeevents = data.lifeEvents;
    },
      error => console.error(error)
    );
  }
}
