import { Component, OnInit } from '@angular/core';
import { CategotyService } from './categoty.service';
import { CategoryModel } from '../models/categoryModel';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  constructor(private categoryService: CategotyService) {

  }

  categories: CategoryModel[];

  ngOnInit() {
    this.categoryService.getCategories().subscribe(b => this.categories = b);
  }

}
