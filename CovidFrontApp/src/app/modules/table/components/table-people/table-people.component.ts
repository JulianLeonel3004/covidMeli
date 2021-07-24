import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/core/person';
import { PeopleService } from 'src/app/modules/home/services/people.service';

@Component({
  selector: 'app-table-people',
  templateUrl: './table-people.component.html',
  styleUrls: ['./table-people.component.scss']
})
export class TablePeopleComponent implements OnInit {

  people:Array<Person> = [];

  constructor(private peopleService:PeopleService) { }

  ngOnInit() {
    this.peopleService.getPeople().subscribe(item=>{
      this.people = item;
    });
  }

}
