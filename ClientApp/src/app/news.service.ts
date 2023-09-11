import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NewsProviderResponse } from './newsproviderresponse';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  getSearch(text: string): Observable<NewsProviderResponse> {


    return this.http.get<NewsProviderResponse>(this.baseUrl + 'news/search', {params: {"searchPhrase": text}})
    .pipe(
      tap(_ => console.log('getSearch')),
      catchError(this.handleError<NewsProviderResponse>('getSearch'))
    );

  }

  getTopHeadlines(category: string): Observable<NewsProviderResponse> {

    return this.http.get<NewsProviderResponse>(this.baseUrl + 'news/topheadlines', {params: {"category": category}})
    .pipe(
      tap(_ => console.log('getTopHeadlines')),
      catchError(this.handleError<NewsProviderResponse>('getTopHeadlines'))
    );

  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead


      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
