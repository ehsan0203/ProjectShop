import { Component ,OnInit } from '@angular/core';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  ngOnInit(){

  }
  title = 'FrontAngular';
  faCoffee = faCoffee;
  itemsPerSlide = 3;
  singleSlideOffset = false;




}
