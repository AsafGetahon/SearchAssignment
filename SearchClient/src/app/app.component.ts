import { Component } from '@angular/core';
import { SearchService } from './shared/search.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SearchClient';

  constructor(private service: SearchService) {
  }

  ngOnInit(): void {
  }
}
