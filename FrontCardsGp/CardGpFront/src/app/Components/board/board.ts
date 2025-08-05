import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PlayerPanel } from '../player-panel/player-panel';
import { CardCarousel } from '../card-carousel/card-carousel';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule, PlayerPanel, CardCarousel],
  templateUrl: './board.html',
  styleUrl: './board.css'
})
export class Board {
  players: any[] = [];

  emptySlots: number[] = [];


constructor(private router: Router) {
  const navigation = this.router.getCurrentNavigation();
  const statePlayers = navigation?.extras.state?.['players'];

  if (statePlayers) {
    this.players = statePlayers.map((p: any, index: number) => ({
      name: p.userName,
      avatar: `assets/perfiles/perfil${(index % 6) + 1}.png`,
      cards: 8
    }));

    this.emptySlots = Array.from({ length: this.players.length });
  } else {
    this.router.navigate(['/lobby']);
  }
}



  myCards = Array.from({ length: 8 }, (_, i) => ({
    image: `assets/CartasSinAtributos/PropertyDefault${i + 1}.png`,
    detailedImage: 'assets/cartasAtributo/CardMoto55.png'
  }));

  selectedCardIndex: number | null = null;

  selectCard(index: number) {
    this.selectedCardIndex = index;
  }
}
