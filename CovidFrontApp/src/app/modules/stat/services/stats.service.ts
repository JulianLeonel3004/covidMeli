import { Injectable } from '@angular/core';
import { HttpClient }  from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })


  export class StatService {
    constructor(private http: HttpClient) { }

    getStats():Observable<any>{ 
        return this.http.get( environment.Api_url +'covid/stats');
      }
  
}
