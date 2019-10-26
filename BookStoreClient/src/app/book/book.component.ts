import { Component, OnInit } from '@angular/core';

import { BookService } from './book.service';
import { Book } from '../models/book';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  constructor(private bookService: BookService) { }
  filterText:'';
  books: Book[];
  basket: Book[] = [];
  keyword: string;

  gender: string = 'female';
  inviteMap: any = { 'male': 'Hoşgeldiniz bayım', 'female': 'Hoşgeldiniz hanımefendi.', 'other': 'Invite them.' };

  ngOnInit() {
    this.bookService.getBooks().subscribe(data => this.books = data);
  }

  addToBasket(book: Book) {
    this.basket.push(book);
    console.log(book.name + " eklendi");

  }


}
