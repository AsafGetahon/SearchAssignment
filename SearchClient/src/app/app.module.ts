import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { QueryResultsComponent } from './query-results/query-results.component';
import { QueryFormComponent } from './query-form/query-form.component';
import { QueryHistoryComponent } from './query-history/query-history.component';

@NgModule({
  declarations: [
    AppComponent,
    QueryResultsComponent,
    QueryFormComponent,
    QueryHistoryComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
