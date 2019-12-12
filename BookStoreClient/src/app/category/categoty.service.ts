import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryModel } from '../models/categoryModel';
import { Observable, from } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategotyService {

  constructor(private http: HttpClient) { }

  getCategories(): Observable<CategoryModel[]> {
    return this.http.get<CategoryModel[]>('http://localhost:62441/api/category').pipe(
      tap(x => console.log(x))
    );
  }

}
