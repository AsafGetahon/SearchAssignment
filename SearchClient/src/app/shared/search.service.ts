import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { IQueryResult } from './queryResult.interface';
import { SearchData } from './search.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) { }

  baseUrl = 'https://localhost:44395/api/Search/';
  formData: SearchData = new SearchData();
  list: SearchData[];
  get queriesResults(): IQueryResult[] {
    return this._queriesResults.getValue();
  }

  set queriesResults(value: IQueryResult[]) {
    this._queriesResults.next(value);
  }
  private _queriesResults = new BehaviorSubject<IQueryResult[]>([]);
  queriesResults$: Observable<IQueryResult[]> = this._queriesResults.asObservable();

  getQueryList() {
    this.http.get(this.baseUrl)
      .toPromise()
      .then(res =>this.list = res as SearchData[]);
  }

postSearchQuery(){
  return this.http.post(this.baseUrl + 'getResults', this.formData).pipe(
    map((results : any) => {
      if(results){
        this._queriesResults.next(results);
      }
      return results;
    })
  )
}

searchAgain(param:SearchData){
  return this.http.post(this.baseUrl + 'getResults', param).pipe(
    map((results : any) => {
      if(results){
        this._queriesResults.next(results);
      }
      return results;
    })
  )
}

  refreshList() {
    this.http.get(this.baseUrl)
      .toPromise()
      .then(res =>this.list = res as SearchData[]);
  }
}
