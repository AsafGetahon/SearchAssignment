import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IQueryResult } from '../shared/queryResult.interface';
import { SearchData } from '../shared/search.model';
import { SearchService } from '../shared/search.service';

@Component({
  selector: 'app-query-form',
  templateUrl: './query-form.component.html',
  styleUrls: ['./query-form.component.scss']
})
export class QueryFormComponent implements OnInit {

  constructor(public service:SearchService) { }
  queryResults: IQueryResult[];
  ngOnInit(): void {
  }


  onSubmit(form: NgForm) {
    this.service.postSearchQuery().subscribe(
      res => {
        this.queryResults = res.result.filter(this.notEmpty) as IQueryResult[];
        console.log(this.queryResults);
        this.resetForm(form);
        this.service.refreshList();
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new SearchData();
  }

  notEmpty<TValue>(value: TValue | null | undefined): value is TValue {
    return value !== null && value !== undefined;
}

}
