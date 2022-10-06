import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Cidade } from '../models/cidade';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  url = 'https://localhost:44397/v1/cidades';

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  getCidades(): Observable<Cidade[]> {
    return this.httpClient.get<Cidade[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getCidadeById(id: number): Observable<Cidade> {
    return this.httpClient.get<Cidade>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  getCidadeByName(nome: string): Observable<Cidade> {
    var tst = this.httpClient.get<Cidade>(this.url + '/' + nome)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )

    return tst;
  }

  saveCidade(cidade: Cidade): Observable<Cidade> {
    return this.httpClient.post<Cidade>(this.url, JSON.stringify(cidade), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  updateCidade(cidade: Cidade): Observable<Cidade> {
    return this.httpClient.put<Cidade>(this.url, JSON.stringify(cidade), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  deleteCidade(cidade: Cidade) {
    return this.httpClient.delete<Cidade>(this.url + '/' + cidade.id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}
