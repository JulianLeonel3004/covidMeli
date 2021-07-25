import { Component, Input, OnInit } from '@angular/core';
import { Person } from 'src/app/core/person';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ViewComponent } from 'src/app/modules/model-analysis/components/view/view.component';

@Component({
  selector: 'app-table-people',
  templateUrl: './table-people.component.html',
  styleUrls: ['./table-people.component.scss']
})
export class TablePeopleComponent implements OnInit {

  @Input() people:Person[];

  constructor(private modalService:NgbModal) { }

  ngOnInit() {
  }

  openPerson(person:Person) {
    const view = this.modalService.open(ViewComponent, { backdrop: true });
    view.componentInstance.person = person;
  }

  

}
