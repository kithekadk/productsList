import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../Interfaces/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getProducts(){
    return this.http.get<Product[]>("http://localhost:5087/api/Product/all")
  }

  createProduct(product:Product){
    return this.http.post<Product>("http://localhost:5087/api/Product", product).subscribe(res=>{
      console.log(res);

      this.getProducts()
      
    })
  }
}
