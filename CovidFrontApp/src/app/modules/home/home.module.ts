import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { TableModule } from '../table/table.module';
import { FilterModule } from '../filter/filter.module';
import { StatModule } from '../stat/stat.module';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  }
];

RouterModule.forChild(routes)

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    TableModule,
    FilterModule,
    StatModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }
