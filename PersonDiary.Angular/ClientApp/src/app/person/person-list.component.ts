import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../models/person';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html'
})
export class PersonListComponent {
  public persons: Person[];

  constructor(http: HttpClient, private dataService: PersonService) {

    this.dataService.getPersons().subscribe((data: any) => {
      this.persons = data.persons;
    },
      error => console.error(error)
    );
  }
}
