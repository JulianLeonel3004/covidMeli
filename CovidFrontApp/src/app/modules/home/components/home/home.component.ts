import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Person } from 'src/app/core/person';
import { CreateComponent } from 'src/app/modules/model-analysis/components/create/create.component';
import { PeopleService } from '../../services/people.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  people: Person[];
  countries: string[];
  results:string[];

  constructor(private peopleService:PeopleService,
    private modalService:NgbModal) { }

  ngOnInit() {
      this.peopleService.getPeople().subscribe(people => {
        this.people = people; 
        this.loadCountriesResults();
      });
  }


  loadCountriesResults(){
    let countries = this.people.map(person => person.country);
    let results = this.people.map(person => person.result);

    this.countries = this.filterRepeats(countries);
    this.results = this.filterRepeats(results);
    
  }

  filterRepeats(arr: any[]) {
   return arr.reduce((acc,item)=>{
      if(acc.indexOf(item)==-1){
        acc.push(item);
      }
      return acc;
    },[]);
  }


  reloadPeople(people:Person[]){console.log(people);
    this.people = people;
  }

  openModal(){
    this.modalService.open(CreateComponent, { backdrop: true }).result.then((result) => {
     alert(result);
    });

  }
  
}
