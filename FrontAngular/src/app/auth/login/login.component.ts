import { Component, OnInit } from '@angular/core';
import { LoginRequest } from 'src/app/models/LoginRequest';
import { FormsModule } from '@angular/forms';
import { AuthService } from 'src/app/service/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
model:LoginRequest;
constructor(private authservice:AuthService,
  private cookieService:CookieService,
  private router:Router){
  this.model={
    email: '',
    password:''
  };
}

  ngOnInit(): void {

  }
  onFormSubmit():void{
    this.authservice.login(this.model).subscribe({
      next:(response)=> {
        this.cookieService.set('Authorization',`Bearer${response.token}`,undefined,'/',undefined,true,'Strict');
        this.authservice.setUser({
          email:response.email,
          roles:response.roles
        });
        this.router.navigateByUrl('/');
      },
      error:(err)=> {
        
      },
      complete:()=> {
        
      },
    })
  }
}
