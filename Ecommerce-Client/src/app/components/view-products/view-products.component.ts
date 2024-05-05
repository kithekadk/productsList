import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';
import { Product, ProductWithFactorial } from '../../Interfaces/Product';

@Component({
  selector: 'app-view-products',
  standalone: true,
  imports: [CommonModule, NgxPaginationModule],
  templateUrl: './view-products.component.html',
  styleUrl: './view-products.component.css'
})
export class ViewProductsComponent {

  products: Product[]=[];
  productswithFactorial: ProductWithFactorial[]=[]

  page: number = 1;

  gettingFactorial:boolean = false

  constructor(private productService:ProductService){
    this.getProducts()
  }


  getProducts(){
    this.gettingFactorial = false
    this.productService.getProducts().subscribe(res=>{
      console.log(res);
      
      this.products = res
    })
  }

  getFactorial(){
    this.gettingFactorial = true
    this.productService.getFactorial().subscribe(res=>{
      console.log(res);
      
      this.productswithFactorial = res
    })
  }
}
