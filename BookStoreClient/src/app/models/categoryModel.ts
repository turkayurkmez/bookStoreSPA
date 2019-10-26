export class CategoryModel {
    id: number;
    name: string;
    categories: CategoryModel[];
    subCategoriesCount: number;
    topCategoryId?: number;
}
