import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LifeEvent } from '../models/lifeevent';
import { LifeEventService } from '../services/lifeevent.service';

@Component({
  selector: 'app-lelist',
  templateUrl: './lelist.component.html'
})
export class LeListComponent {
  public leevents: LifeEvent[];

  constructor(http: HttpClient, private dataService: LifeEventService) {

    this.dataService.getLifeEvents().subscribe((data: any) => {
      this.leevents = data.lifeEvents;
    },
      error => console.error(error)
    );
  }
}
