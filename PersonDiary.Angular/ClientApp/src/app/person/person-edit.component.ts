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
      this.dataService.updatePerson(this.person).subscribe((data: any) => { }) :
      this.dataService.createPerson(this.person).subscribe((data: any) => {
        //this.router.navigate(['/person-edit', data.person.id]);
        this.person = data.person;
        this.lifeevents = data.person.lifeEvents;
      });
  }
  add_lifeevent() {
    this.router.navigate(['/lifeevent-create', this.person.id]); 
  }
  delete() {
    this.dataService.deletePerson(this.person.id).subscribe((data: any) => {
      let show_alert:boolean = data.messages.filter(m => m.type == 1).length > 0;
      if (!show_alert) { this.router.navigate(['/person-list']); }

    });
  }
}

