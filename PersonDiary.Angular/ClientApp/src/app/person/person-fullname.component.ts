import { Component,Input,OnInit } from '@angular/core';
import { PersonService } from '../services/person.service';


@Component({
  selector: 'app-person-fullname',
  templateUrl: './person-fullname.component.html'
})
export class PersonFullNameComponent{
  @Input() id: number;
  public personfullname: string;
  

  constructor(private dataService: PersonService) {
    
  
  }
  ngOnInit() {
    if (this.id) {
      this.dataService.getPerson(this.id).subscribe((data: any) => {
        this.personfullname = data.person.name + " " + data.person.surname;
      });
    }
  }
}

