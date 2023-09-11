import { Component } from '@angular/core';
import { NewsProviderResponse } from '../newsproviderresponse';
import { NewsService } from '../news.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  public searchResult: NewsProviderResponse;

  constructor(private newsService: NewsService) {

  }

  search(text: string){
    this.newsService.getSearch(text).subscribe(r => this.searchResult = r);
  }
}




