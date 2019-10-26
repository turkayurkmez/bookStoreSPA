import { Author } from './author';
import { category } from './category';

export class Book
{
    bookId: number;
    name: string;
    description: string;
    price: number;
    rate: number;
    coverImagePath: string;
    coverImage: number[];
    author: Author;
    authorId: number;
    categories: category[];

}