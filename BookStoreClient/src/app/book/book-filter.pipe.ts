import { Pipe, PipeTransform } from '@angular/core';
import { Book } from '../models/book';

@Pipe({
  name: 'bookFilter'
})
export class BookFilterPipe implements PipeTransform {

  transform(value: Book[], filterText?: string): Book[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : null;

    return filterText ? value.filter(b => b.name.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }

}
