import { Component, OnInit } from '@angular/core';
import { ShopPortfolio } from '../models/shopPortfolio';
import { ShopService } from '../service/shop.service';

@Component({
  selector: 'app-slider-portfolio',
  templateUrl: './slider-portfolio.component.html',
  styleUrls: ['./slider-portfolio.component.css']
})
export class SliderPortfolioComponent implements OnInit {

  portfolios:ShopPortfolio[]=[];

  constructor(private portfolioservice:ShopService){

  }
  ngOnInit(): void {
    this.portfolioservice.getportfolios().subscribe({
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

  isMobile = window.innerWidth < 900;



}
