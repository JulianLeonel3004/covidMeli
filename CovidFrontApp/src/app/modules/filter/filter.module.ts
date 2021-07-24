import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from './components/filter/filter.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [FilterComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [FilterComponent]
})
export class FilterModule { }
