import { Component, Input } from '@angular/core';
import { NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-general',
  templateUrl: './modal-general.component.html',
  styleUrls: ['./modal-general.component.scss']
})
export class ModalGeneralComponent{

  @Input() title: string;
  @Input() message: string;
  @Input() actionModal:Function;

  constructor(public modal: NgbActiveModal) { }

  ngOnInit() {
  }

  confirm() {
    this.actionModal();
    this.modal.dismiss('confirm click');
  }

}









