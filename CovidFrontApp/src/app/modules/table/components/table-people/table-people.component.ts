import { Component, Input, OnInit } from '@angular/core';
import { Person } from 'src/app/core/person';

@Component({
  selector: 'app-table-people',
  templateUrl: './table-people.component.html',
  styleUrls: ['./table-people.component.scss']
})
export class TablePeopleComponent implements OnInit {

  @Input() people:Person[];

  constructor() { }

  ngOnInit() {
  }

}
