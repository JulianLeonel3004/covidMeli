import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PeopleService } from 'src/app/modules/home/services/people.service';

const FILTER_COUNTRY = 1;
const FILTER_RESULT = 2;

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  @Input() countries:Array<string>;
  @Output() filterOutput:EventEmitter<any> = new EventEmitter();

  results = [ 'infected','healthy','inmune'];

  filterByCountry:boolean = false;
  filterByResult:boolean = false;

  select:string;

  constructor(private peopleService:PeopleService) { }

  ngOnInit() {
    
  }


  filter(){
    let filterType =  this.filterByCountry ? FILTER_COUNTRY : this.filterByResult ? FILTER_RESULT : null;
    
    if(filterType == null) return;

    this.peopleService.getPeopleByFilter(filterType,this.select).subscribe(item=>{
      this.filterOutput.emit(item);
    });
      
  }



  changeFilter(event){
    let value = event.target.value;
    
    if(value ==  FILTER_COUNTRY)
      this.filterByCountry = true;
    else if(value ==  FILTER_RESULT)
      this.filterByResult = true;

  }

}
