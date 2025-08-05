import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { CardCarousel } from '../card-carousel/card-carousel';
import { PlayerPanel } from '../player-panel/player-panel';

@Component({
  selector: 'app-board',
  imports: [CommonModule,
    PlayerPanel,
    CardCarousel],
  templateUrl: './board.html',
  styleUrl: './board.css'
})
export class Board {
  players = [
    { name: 'polit01', avatar: 'assets/perfiles/perfil1.png', cards: 8 },
    { name: 'motor69', avatar: 'assets/perfiles/perfil2.png', cards: 8 },
    { name: 'chingo00', avatar: 'assets/perfiles/perfil3.png', cards: 8 },
    { name: 'terrenietor99', avatar: 'assets/perfiles/perfil4.png', cards: 8 },
    { name: 'tralalelo100', avatar: 'assets/perfiles/perfil5.png', cards: 8 },
    { name: 'mataton_01', avatar: 'assets/perfiles/perfil6.png', cards: 8 },
  ];

  // 🔁 Puedes cambiar 5 por 10, 15, etc. según el mazo que quieras mostrar
  myCards = Array.from({ length: 8 }, (_, i) => ({
  image: `assets/CartasSinAtributos/PropertyDefault${i + 1}.png`,
  detailedImage: 'assets/cartasAtributo/CardMoto55.png'
    }));


  selectedCardIndex: number | null = null;

  selectCard(index: number) {
    this.selectedCardIndex = index;
  }
}

