import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BookComponent } from './book/book.component';
import { HttpClientModule } from '@angular/common/http';
import { BookService } from './book/book.service';
import { FormsModule } from '@angular/forms';
import { BookFilterPipe } from './book/book-filter.pipe';
import { CategoryComponent } from './category/category.component' ;


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BookComponent,
    BookFilterPipe,
    CategoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [BookService, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
