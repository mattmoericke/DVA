import { Component } from '@angular/core';
import { NewsProviderResponse } from '../newsproviderresponse';
import { NewsService } from '../news.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public searchResult: NewsProviderResponse;

  constructor(private newsService: NewsService) {
    this.topHeadlines("technology");
  }

  topHeadlines(category: string){

    this.newsService.getTopHeadlines(category).subscribe(r => this.searchResult = r);
  }
}
