import { Injectable } from '@angular/core';
import { ShopPortfolio } from '../models/shopPortfolio';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { ShopBlog } from '../models/shop-blog';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  portfolios:ShopPortfolio[]=[]
  blogs:ShopBlog[]=[]
  constructor(private httpClient:HttpClient) {

   }
   public getportfolios():Observable<ShopPortfolio[]>{
    return this.httpClient.get<ShopPortfolio[]>("https://localhost:7060/api/Portfolio")
   }
   public getblogs():Observable<ShopBlog[]>{
    return this.httpClient.get<ShopBlog[]>("https://localhost:7060/api/Blog")
   }
   public postportfolios(portfolio:FormData):Observable<FormData>{
    return this.httpClient.post<FormData>("https://localhost:7060/api/portfolio/post",portfolio)
   }
   public postBlogs(blog:FormData):Observable<FormData>{
    return this.httpClient.post<FormData>("https://localhost:7060/api/Blog/post",blog)
   }
}
