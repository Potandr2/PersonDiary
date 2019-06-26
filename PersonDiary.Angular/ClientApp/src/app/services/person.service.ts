import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Person } from '../models/person';
import { LifeEvent } from '../models/LifeEvent';

@Injectable()
export class PersonService {

  private url = "/api/person";

  constructor(private http: HttpClient) {
  }

  getPersons() {
    const p = new HttpParams().append('json', JSON.stringify({ withLifeEvents: true }));
    return this.http.get(this.url, { params: p });
  }

  getPerson(id: number) {
    return this.http.get(this.url+'/'+id);
  }

  createPerson(person: Person) {
    return this.http.post(this.url + '/' + person.id, { person });
  }

  updatePerson(person: Person) {
    return this.http.put(this.url + '/' + person.id, { person });
  }

  deletePerson(id: number) {
    return this.http.delete(this.url + '/' + id);
  }


}
