import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Person } from 'src/app/core/person';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {

  @Input() person:Person;
  constructor(private modal: NgbActiveModal) { }

  ngOnInit() {
  }

  dismiss(){
    this.modal.dismiss('confirm click');
  }


}
