import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalGeneralComponent } from './components/modal-general/modal-general.component';


@NgModule({
  declarations: [ModalGeneralComponent],
  imports: [
    NgbModule,
    CommonModule
  ],
  exports:[
    ModalGeneralComponent
  ]
})

export class SharedModule { }
