import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ShopBlog } from 'src/app/models/shop-blog';
import { ShopPortfolio } from 'src/app/models/shopPortfolio';
import { ShopService } from 'src/app/service/shop.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit{
  selectedFile: File | null = null;
  title = '';
  fileTitle='';
  fileDescription = '';
  fileName='';
  portfolios:ShopPortfolio[]=[];
  blogs:ShopBlog[]=[]
  // postBlogForm: FormGroup;
  // postPortfoliosForm:FormGroup;


  constructor(private blogservice:ShopService){

  }
  ngOnInit(): void {
    this.blogservice.getblogs().subscribe({
      next:(response : ShopBlog[])=> {
        this.blogs=response
      },
      error:(err:any) =>{
        console.log(err)
      },
      complete:() =>{
        
      },
    });
    this.blogservice.getportfolios().subscribe({
      next:(response : ShopPortfolio[])=> {
        this.portfolios=response
      },
      error:(err:any) =>{
        console.log(err)
      },
      complete:() =>{
        
      },
    })

  }
 

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  onUploadblog() {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);
      formData.append('FileName', this.fileName);
      formData.append('Title', this.title);
      formData.append('FileDescription', this.fileDescription);

      // ارسال اطلاعات به API ASP.NET
      this.blogservice.postBlogs(formData).subscribe(
        (response) => {
          console.log('آپلود موفقیت‌آمیز', response);
        },
        (error) => {
          console.error('خطا در آپلود', error);
        }
      );
    }
  }
  onUploadPort() {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);
      formData.append('FileName', this.fileName);
      formData.append('Filetitle', this.fileTitle);

      // ارسال اطلاعات به API ASP.NET
      this.blogservice.postportfolios(formData).subscribe(
        (response) => {
          console.log('آپلود موفقیت‌آمیز', response);
        },
        (error) => {
          console.error('خطا در آپلود', error);
        }
      );
    }
  }
}

