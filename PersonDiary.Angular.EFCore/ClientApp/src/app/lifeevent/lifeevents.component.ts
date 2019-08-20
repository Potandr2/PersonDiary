import { Component } from '@angular/core';
import { LifeEvent } from '../models/lifeevent';
import { LifeEventService } from '../services/lifeevent.service';


@Component({
  selector: 'app-lifeevents',
  templateUrl: './lifeevents.component.html'
})
export class LifeEventsComponent {
  public lifeevents: LifeEvent[];

  constructor(private dataService: LifeEventService) {

    this.dataService.getLifeEvents().subscribe((data: any) => {
      this.lifeevents = data.lifeEvents;
    },
      error => console.error(error)
    );
  }
}
