import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatsComponent } from './components/stats/stats.component';



@NgModule({
  declarations: [StatsComponent],
  imports: [
    CommonModule
  ],
  exports: [StatsComponent]
})
export class StatModule { }
