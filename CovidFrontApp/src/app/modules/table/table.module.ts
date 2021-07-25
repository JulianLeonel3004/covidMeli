import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TablePeopleComponent } from './components/table-people/table-people.component';
import { ModelAnalysisModule } from '../model-analysis/model-analysis.module';
import { ViewComponent } from '../model-analysis/components/view/view.component';



@NgModule({
  declarations: [TablePeopleComponent],
  imports: [
    CommonModule,
    ModelAnalysisModule
  ],
  exports: [TablePeopleComponent],
  entryComponents:[ViewComponent]
})
export class TableModule { }
