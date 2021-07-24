import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Generic } from 'src/app/core/generic';
import { PeopleService } from 'src/app/modules/home/services/people.service';

const FILTER_COUNTRY = 1;
const FILTER_RESULT = 2;

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

    //TODO: Que sean inputs
  /*********************************************/
  // results = [ 'infected', 'healthy', 'inmune'];
  // countries = ['Argentina','Brasil'];
  /*********************************************/
  @Input() countries:string[];
  @Input() results:string[];

  @Output() filterOutput:EventEmitter<any> = new EventEmitter();

  filtersBy = [new Generic(FILTER_COUNTRY,'País'), new Generic(FILTER_RESULT,'Resultado')];
  formFilter:FormGroup;
  filters;

  constructor(private peopleService:PeopleService,
    private formBuilder:FormBuilder) { }

  ngOnInit() {
    this.formFilter =this.formBuilder.group({
      filterBy: [FILTER_COUNTRY, [Validators.required]],
      filter: [null, [Validators.required]]
    });

    this.filters = this.countries;
  }


  onSubmit(){
    if(this.formFilter.invalid)
      return;

    this.filter();
  }

  changeFilters(){
    this.filters = this.formFilter.value.filterBy == FILTER_COUNTRY ? this.countries : this.results;
  }


  private filter(){
    this.peopleService.getPeopleByFilter(Number(this.formFilter.value.filterBy),this.formFilter.value.filter).subscribe(item=>{
      this.filterOutput.emit(item);
    });
      
  }


}
