import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Person } from '../models/Person';
import { LifeEvent } from '../models/LifeEvent';
import { CommonUtils } from '../common/common.utils';

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
    lifeevent.eventdate = CommonUtils.correctDate2UTC(lifeevent.eventdate);
    return this.http.post(this.url, { lifeevent });
  }

  updateLifeEvent(lifeevent: LifeEvent) {
    lifeevent.eventdate = CommonUtils.correctDate2UTC(lifeevent.eventdate);
    return this.http.put(this.url + '/' + lifeevent.id, { lifeevent });
  }

  deleteLifeEvent(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

  

}
