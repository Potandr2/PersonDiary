import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../models/person';
import { PersonService } from '../services/person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html'
})
export class PersonListComponent {
  public persons: Person[];
  public count: number;
  public PageNo: number;

  constructor(http: HttpClient, private dataService: PersonService, private router: Router) {
    this.PageNo = 0;
    this.getPageItems();
  }
  getPageItems() {
    this.dataService.getPersons(this.PageNo).subscribe((data: any) => {
      this.persons = data.persons;
      this.count = data.count;
    },
      error => console.error(error)
    );
  }
  add() {
    this.router.navigate(['/person']);
  }
  pageChanged(event: any): void {
    this.PageNo = event.page-1;
    this.getPageItems();
  }
}
