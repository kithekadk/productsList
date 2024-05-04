import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent{
  createProductForm!: FormGroup;
  imageUrl = ""
  clicked = false

  constructor(private fb:FormBuilder, private productService:ProductService, private router: Router){
    this.createProductForm = this.fb.group({
      name: ['',[Validators.required]],
      description: ['',[Validators.required]],
      price: ['', [Validators.required]],
      imageUrl: ['',[Validators.required]]
    })
  }

  getImageUrl(event:any){
    this.imageUrl = ""
    this.clicked =true
    const files = event.target.files
    
    if(files){
      const formData = new FormData()
      formData.append("file", files[0])
      formData.append("upload_preset", "ispiral")
      formData.append("cloud_name", "dtn9kzx2v")

      fetch('https://api.cloudinary.com/v1_1/dtn9kzx2v/image/upload', {
          method: "POST",
          body: formData
      }).then((res) => res.json()).then(res => {

        this.imageUrl = res.url

        console.log(this.imageUrl);
        

        this.createProductForm.patchValue({'imageUrl': this.imageUrl})
      })

      
  }
    
  }
  createProduct(){    
    this.productService.createProduct(this.createProductForm.value)
    this.createProductForm.reset()
  }

  navigate(){

  window.location.reload()
  
}
}
