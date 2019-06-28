import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../models/person';
import { PersonService } from '../services/person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html'
})
export class PersonListComponent {
  public persons: Person[];

  constructor(http: HttpClient, private dataService: PersonService, private router: Router) {

    this.dataService.getPersons().subscribe((data: any) => {
      this.persons = data.persons;
    },
      error => console.error(error)
    );
  }

  add() {
    this.router.navigate(['/person-edit']);
  }
}
