import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) {

  }

  getBooks(): Observable<Book[]> {
     return this.http.get<Book[]>('http://localhost:62441/api/book');
  }
}
