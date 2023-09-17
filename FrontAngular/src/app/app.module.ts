import {CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CarouselModule } from 'ngx-bootstrap/carousel';
// import function to register Swiper custom elements
import { register } from 'swiper/element/bundle';
import { HeaderComponent } from './header/header.component';
import { SliderHeaderComponent } from './slider-header/slider-header.component';
import { SliderPortfolioComponent } from './slider-portfolio/slider-portfolio.component';
import { ServicesComponent } from './services/services.component';
import { BlogComponent } from './blog/blog.component';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxTypedJsModule } from 'ngx-typed-js';
import { LoginComponent } from './auth/login/login.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminPageComponent } from './auth/admin-page/admin-page.component';
import { MainComponent } from './core/main/main.component';
// register Swiper custom elements
register();





@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    SliderHeaderComponent,
    SliderPortfolioComponent,
    ServicesComponent,
    BlogComponent,
    FooterComponent,
    LoginComponent,
    AdminPageComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    CarouselModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgxTypedJsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule

  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
