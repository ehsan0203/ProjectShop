import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {Product} from './models/product'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'FrontProAngular';
  products:Product[]=[];

  constructor(private http:HttpClient){

  }
  ngOnInit(): void {
    this.http.get<Product[]>('https://localhost:7280/api/Product').subscribe({
      next : (response) => 
        
        this.products =response
        // console.log(response)
      ,
      error : err =>{
        console.log(err)
      },
      complete() {
        console.log("request Complated")
        console.log("extra statmet")

      },
    })
  }

}
