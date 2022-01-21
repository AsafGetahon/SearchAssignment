import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IQueryResult } from '../shared/queryResult.interface';
import { SearchData } from '../shared/search.model';
import { SearchService } from '../shared/search.service';

@Component({
  selector: 'app-query-history',
  templateUrl: './query-history.component.html',
  styleUrls: ['./query-history.component.scss']
})
export class QueryHistoryComponent implements OnInit {
  @Input() resultsData: IQueryResult[];
  constructor(public service: SearchService) { }
  queryHistory: SearchData[] = [];

  ngOnInit(): void {
    this.service.getQueryList();
  }

  onSubmit(form: NgForm) {
    this.service.postSearchQuery();
  }

  notEmpty<TValue>(value: TValue | null | undefined): value is TValue {
    return value !== null && value !== undefined;
}
}
