import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LifeEvent } from '../models/lifeevent';
import { LifeEventService } from '../services/lifeevent.service';

@Component({
  selector: 'app-lifevent-list',
  templateUrl: './lifevent-list.html'
})
export class LifeEventListComponent {
  public lifeevents: LifeEvent[];

  constructor(http: HttpClient, private dataService: LifeEventService) {

    this.dataService.getLifeEvents().subscribe((data: any) => {
      this.lifeevents = data.lifeevent;
    },
      error => console.error(error)
    );
  }
}
