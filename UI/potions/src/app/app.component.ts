import { Component, OnInit } from '@angular/core';
import { PotionsService } from './service/potions.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'potions';
  constructor(private potionsService: PotionsService){

  }

  ngOnInit(): void {
    
  }

  getAllPotions(){
    this.potionsService.getAllPotions().subscribe(
      response => {
        console.log(response);
      }
    );
  }
}
