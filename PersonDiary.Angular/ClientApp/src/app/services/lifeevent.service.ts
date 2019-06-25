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
    return this.http.post(this.url + '/' + lifeevent.id, lifeevent);
  }

  updateLifeEvent(lifeevent: LifeEvent) {
    return this.http.put(this.url + '/' + lifeevent.id, lifeevent);
  }

  deleteLifeEvent(id: number) {
    return this.http.delete(this.url + '/' + id);
  }


}
