import { Category } from "./category";

export interface Product {
    productId: number;
    description: string;
    price: number;
    productQuantity: number;
    categoryId: number;
    categoryName: string;
    category: Category
}
