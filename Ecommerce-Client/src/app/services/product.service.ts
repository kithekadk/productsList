import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product, ProductWithFactorial } from '../Interfaces/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getProducts(){
    return this.http.get<Product[]>("http://localhost:9100/api/Product/all")
  }

  getFactorial(){
    return this.http.get<ProductWithFactorial[]>("http://localhost:9100/api/Product/factorial")
  }

  createProduct(product:Product){
    return this.http.post<Product>("http://localhost:9100/api/Product", product)
  }
}
