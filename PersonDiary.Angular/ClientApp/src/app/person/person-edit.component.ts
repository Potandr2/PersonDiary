import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Person } from '../models/person';
import { LifeEvent } from '../models/lifeevent';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html'
})
export class PersonEditComponent implements OnInit {
  public id: any;
  public person: Person;
  public lifeevents: LifeEvent[];
  private subscription: Subscription;

  constructor(http: HttpClient, private activateRoute: ActivatedRoute, private dataService: PersonService) {

    this.subscription = activateRoute.params.subscribe(
      params => {
        this.id = params['id'];

        this.dataService.getPerson(this.id).subscribe((data: any) => {
          this.person = data.person;
          this.lifeevents = data.person.lifeEvents;
        });

       
      }
    );

  }
  ngOnInit() {

  }
  save() {
    this.dataService.updatePerson(this.person).subscribe((data: any) => {
    
    });

   
  }
}

