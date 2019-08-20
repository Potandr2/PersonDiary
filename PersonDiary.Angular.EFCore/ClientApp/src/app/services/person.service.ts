import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Person } from '../models/person';

@Injectable()
export class PersonService {

  private url = "/api/person";

  constructor(private http: HttpClient) {
  }

  getPersons(PageNo:number) {
    const p = new HttpParams().append('json', JSON.stringify({ PageNo,PageSize:10 }));
    return this.http.get(this.url, { params: p });
  }

  getPerson(id: number) {
    return this.http.get(this.url+'/'+id);
  }

  createPerson(person: Person) {
    return this.http.post(this.url, { person });
  }

  updatePerson(person: Person) {
    return this.http.put(this.url + '/' + person.id, { person });
  }

  deletePerson(id: number) {
    return this.http.delete(this.url + '/' + id);
  }


}
