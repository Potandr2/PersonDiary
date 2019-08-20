import { Component, TemplateRef} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Person } from '../models/person';
import { LifeEvent } from '../models/lifeevent';
import { PersonService } from '../services/person.service';
import { Router } from '@angular/router';
import { ModalModule } from 'ngx-bootstrap';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CommonUtils } from '../common/common.utils';


@Component({
  selector: 'app-person',
  templateUrl: './person.component.html'
})
export class PersonComponent  {
  private id: any;
  private person: Person;
  private lifeevents: LifeEvent[];

  private modalRef: BsModalRef;
  private show_alert: boolean = false;
  private show_ok: boolean = false;
  private messages: string;

  constructor(
    private activateRoute: ActivatedRoute,
    private dataService: PersonService,
    private router: Router,
    private modalService: BsModalService
  ) {

    this.activateRoute.params.subscribe(
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
        this.show_alert = data.messages.filter(m => m.type == 1).length > 0;
        if (this.show_alert) { this.messages = CommonUtils.getErorrMessagesText(data.messages); }
        this.show_ok = !this.show_alert;
      }) :
      this.dataService.createPerson(this.person).subscribe((data: any) => {
        this.person = data.person;
        this.lifeevents = data.person.lifeEvents;
        this.show_alert = data.messages.filter(m => m.type == 1).length > 0;
        if (this.show_alert) { this.messages = CommonUtils.getErorrMessagesText(data.messages); }
        this.show_ok = !this.show_alert;
      });
  }
  add_lifeevent() {
    this.router.navigate(['/lifeevent-create', this.person.id]); 
  }
  delete() {
    this.modalRef.hide();

    this.dataService.deletePerson(this.person.id).subscribe((data: any) => {
      let show_alert:boolean = data.messages.filter(m => m.type == 1).length > 0;
      if (!show_alert) { this.router.navigate(['/persons']); }

    });
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
}

