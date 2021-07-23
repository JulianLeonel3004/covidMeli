import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TablePeopleComponent } from './components/table-people/table-people.component';



@NgModule({
  declarations: [TablePeopleComponent],
  imports: [
    CommonModule
  ],
  exports: [TablePeopleComponent]
})
export class TableModule { }
