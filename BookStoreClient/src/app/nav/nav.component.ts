import { Component, OnInit } from '@angular/core';
import { CategotyService } from '../category/categoty.service';
import { CategoryModel } from '../models/categoryModel';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private categoryService : CategotyService) { }

  categories: CategoryModel[];

  ngOnInit() {
    this.categoryService.getCategories().subscribe(data => this.categories = data);
  }

}
