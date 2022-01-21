import { Component, OnInit, Input } from '@angular/core';
import { SearchService } from '../shared/search.service';
import { IQueryResult } from '../shared/queryResult.interface';
@Component({
  selector: 'app-query-results',
  templateUrl: './query-results.component.html',
  styleUrls: ['./query-results.component.scss']
})
export class QueryResultsComponent implements OnInit {

  @Input() resultsData: IQueryResult[];

  constructor(service : SearchService) { }

  ngOnInit(): void {
    this.resultsData;
  }

}
