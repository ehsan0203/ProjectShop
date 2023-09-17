import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { User } from '../models/user';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  user?:User;

  constructor(private authService:AuthService,private router:Router){

  }


  ngOnInit(): void {
this.authService.user().subscribe({
  next:(response)=> {
    this.user=response;
  },
});
this.authService.getUser();
  }
  onLogOut():void{
    this.authService.logout();
    this.router.navigateByUrl('/');
  }

}
