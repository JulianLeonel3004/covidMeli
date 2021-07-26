import { Injectable } from '@angular/core';
import { HttpClient }  from '@angular/common/http'
import { Observable } from 'rxjs';
import { Person } from 'src/app/core/person';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })


  export class PeopleService {
    constructor(private http: HttpClient) { }


    getPeople():Observable<any>{ 
      return this.http.get(environment.Api_url + '/covid/checks');
    }

    getPeopleByFilter(x:number, y:string, z?:string):Observable<any>{
      if(z == null)
        z = '';
      else
        z = ','+ z;
      return this.http.get(environment.Api_url + '/covid/checks/search?key='+ x +'&values='+ y + z);
    }

    getPerson(id:number):Observable<any>{ 
      return this.http.get(environment.Api_url + '/covid/checks');
    }

    insertPerson(person:Person){
      return this.http.post(environment.Api_url + '/covid/checks', person);
    }
  }