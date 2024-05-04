import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { ViewProductsComponent } from '../view-products/view-products.component';
import { AddProductComponent } from '../add-product/add-product.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavbarComponent, ViewProductsComponent, AddProductComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
