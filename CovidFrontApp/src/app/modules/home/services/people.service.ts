import { Injectable } from '@angular/core';
import { HttpClient }  from '@angular/common/http'
import { Observable } from 'rxjs';
import { Person } from 'src/app/core/person';

@Injectable({
    providedIn: 'root'
  })


  export class PeopleService {
    constructor(private http: HttpClient) { }


    getPeople():Observable<any>{ 
      return this.http.get('covid/checks');
    }

    getPeopleByFilter(x:number, y:string, z?:string):Observable<any>{
      if(z == null)
        z = '';
      return this.http.get('covid/checks/search?key='+ x +'&values='+ y +','+ z);
    }

    getPerson(id:number):Observable<any>{ 
      return this.http.get('covid/checks');
    }

    insertPerson(person:Person){
      return this.http.post('covid/checks', person);
    }
  }