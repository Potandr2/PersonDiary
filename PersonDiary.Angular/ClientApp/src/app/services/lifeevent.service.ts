import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Person } from '../models/Person';
import { LifeEvent } from '../models/LifeEvent';

@Injectable()
export class LifeEventService {

  private url = "/api/lifeevent";

  constructor(private http: HttpClient) {
  }

  getLifeEvents() {
    return this.http.get(this.url);
  }

  getLifeEvent(id: number) {
    return this.http.get(this.url+'/'+id);
  }

  createLifeEvent(lifeevent: LifeEvent) {
    lifeevent.eventDate = this.correct2UTC(lifeevent.eventDate);
    return this.http.post(this.url + '/' + lifeevent.id, { lifeevent });
  }

  updateLifeEvent(lifeevent: LifeEvent) {
    lifeevent.eventDate = this.correct2UTC(lifeevent.eventDate);
    return this.http.put(this.url + '/' + lifeevent.id, { lifeevent });
  }

  deleteLifeEvent(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

  correct2UTC(date: Date) {
    var now_utc = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate()));
    return now_utc;
  }

}
