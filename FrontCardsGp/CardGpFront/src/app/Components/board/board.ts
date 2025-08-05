import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PlayerPanel } from '../player-panel/player-panel';
import { CardCarousel } from '../card-carousel/card-carousel'; 
import { CardModal, CardData } from '../../card-modal/card-modal';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule, PlayerPanel, CardCarousel, CardModal], // Corrección aquí
  templateUrl: './board.html',
  styleUrl: './board.css'
})
export class Board {
  players: any[] = [];
  emptySlots: number[] = [];

  // Modal properties
  isModalVisible: boolean = false;
  selectedModalCard: CardData | null = null;
  
  // Battle area properties
  battleCards: (CardData | null)[] = [];

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
      this.battleCards = Array.from({ length: this.players.length }, () => null);
    } else {
      this.router.navigate(['/lobby']);
    }
  }

  myCards: CardData[] = Array.from({ length: 8 }, (_, i) => ({
    image: `assets/CartasSinAtributos/cartaMoto1.0.png`,
    detailedImage: 'assets/cartasAtributo/CardMotoA1.0.png',
    name: `Moto ${i + 1}`,
    brand: 'Kawasaki'
  }));

  selectedCardIndex: number | null = null;

  selectCard(index: number) {
    this.selectedCardIndex = index;
    // Show modal when a card is selected
    this.selectedModalCard = this.myCards[index];
    this.isModalVisible = true;
  }

  closeModal() {
    this.isModalVisible = false;
    this.selectedModalCard = null;
  }

  launchCard(cardData: CardData) {
    // Place the card in the current player's battle position (index 0 for current player)
    this.battleCards[0] = cardData;
    
    // Remove the card from player's hand
    if (this.selectedCardIndex !== null) {
      this.myCards.splice(this.selectedCardIndex, 1);
      this.selectedCardIndex = null;
    }
    
    console.log('Card launched to battle area:', cardData);
  }
}