import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-view-products',
  standalone: true,
  imports: [CommonModule, NgxPaginationModule],
  templateUrl: './view-products.component.html',
  styleUrl: './view-products.component.css'
})
export class ViewProductsComponent {

  products:any;

  page: number = 1;

  constructor(private productService:ProductService){
    this.getProducts()
  }


  getProducts(){
    this.productService.getProducts().subscribe(res=>{
      console.log(res);
      
      this.products = res.products
    })
  }
}