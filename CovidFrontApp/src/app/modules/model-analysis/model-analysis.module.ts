import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './components/create/create.component';
import { ViewComponent } from './components/view/view.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [CreateComponent, ViewComponent],
  imports: [
    CommonModule,
    NgbModule,
    SharedModule
  ],
  exports:[CreateComponent, ViewComponent]
})
export class ModelAnalysisModule { }
