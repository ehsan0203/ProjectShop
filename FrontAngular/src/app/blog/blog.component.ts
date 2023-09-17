import { Component, OnInit } from '@angular/core';
import { ShopBlog } from '../models/shop-blog';
import { ShopService } from '../service/shop.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit{
  blogs:ShopBlog[]=[]
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
})
  }
  isMobile = window.innerWidth < 900;
 
  slides = [
    {image: '../assets/images/p1.jpg'},
    {image: '../assets/images/p2.jpg'},
    {image: '../assets/images/p3.jpg'},
    {image: '../assets/images/p1.jpg'},
    {image: '../assets/images/p2.jpg'},
    {image: '../assets/images/p3.jpg'},

  ];
}
