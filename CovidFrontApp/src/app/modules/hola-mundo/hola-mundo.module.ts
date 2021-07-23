import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HolaMundoComponent } from './components/hola-mundo/hola-mundo.component';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from 'src/app/shared/shared.module';
import { ModalGeneralComponent } from 'src/app/shared/components/modal-general/modal-general.component';

const routes: Routes = [
  {
    path: 'ej',
    component: HolaMundoComponent
  }
];

RouterModule.forChild(routes)

@NgModule({
  declarations: [HolaMundoComponent],
  imports: [
    NgbModule,
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ],
  exports:[
    HolaMundoComponent
  ],
  entryComponents:[
    ModalGeneralComponent
  ]
  
})
export class HolaMundoModule { }
