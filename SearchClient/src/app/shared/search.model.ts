export class SearchData {
  id:number;
  querySearched: string;
  dateLastSearched: Date;

  constructor(){
    this.id=0;
    this.querySearched = "";
    this.dateLastSearched = new Date();
  }
}
