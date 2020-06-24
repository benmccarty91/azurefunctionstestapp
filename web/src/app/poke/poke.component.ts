import { Component, OnInit } from '@angular/core';
import { PokeService } from 'src/services/pokeService';

@Component({
  selector: 'app-poke',
  templateUrl: './poke.component.html',
  styleUrls: ['./poke.component.css']
})
export class PokeComponent implements OnInit {

  public data: any;

  constructor(
    private pokeService: PokeService
  ) {
   }

  ngOnInit(): void {
    this.pokeService.getPokeData().subscribe(x => {
      this.data = x;
    });
  }

  getData(): string {
    return JSON.stringify(this.data);
  }

}
