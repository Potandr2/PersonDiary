import { Component} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Person } from '../models/person';
import { LifeEvent } from '../models/lifeevent';
import { PersonService } from '../services/person.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html'
})
export class PersonEditComponent  {
  public id: any;
  public person: Person;
  public lifeevents: LifeEvent[];
  private subscription: Subscription;

  constructor(private activateRoute: ActivatedRoute, private dataService: PersonService, private router: Router) {

    this.subscription = activateRoute.params.subscribe(
      params => {
        this.id = params['id'];
        if (this.id) {
          this.dataService.getPerson(this.id).subscribe((data: any) => {
            this.person = data.person;
            this.lifeevents = data.person.lifeEvents;
          });
        } else {
          this.person = new Person();
        }
      }
    );
  }
 
  save() {
    (this.person.id) ?
      this.dataService.updatePerson(this.person).subscribe((data: any) => {

      }) :
      this.dataService.createPerson(this.person).subscribe((data: any) => { });

   
  }
  add_lifeevent() {
    this.router.navigate(['/lifeevent-create', this.person.id]); 
  }
}

