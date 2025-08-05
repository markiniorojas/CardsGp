import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlayerPanel } from '../player-panel/player-panel';
import { CardCarousel } from '../card-carousel/card-carousel';
import { CardModal } from '../../card-modal/card-modal';
import { PlayerCardDto } from '../../shared/models/PlayerCardDto';
import { FormsModule } from '@angular/forms';
import { RoundService } from '../../services/controllerEspecificos/round.service';
import { AttributeToCompare } from '../../shared/models/AttributeToCompare ';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule, FormsModule, PlayerPanel, CardCarousel, CardModal],
  templateUrl: './board.html',
  styleUrl: './board.css'
})
export class Board implements OnInit {
  players: any[] = [];
  emptySlots: number[] = [];
  currentPlayerIndex: number = 0;

  isModalVisible: boolean = false;
  selectedModalCard: PlayerCardDto | null = null;

  battleCards: (PlayerCardDto | null)[] = [];
  selectedCardIndex: number | null = null;
  playerHands: PlayerCardDto[][] = [];

  attributeToCompare: AttributeToCompare | null = null;
  attributeOptions = Object.values(AttributeToCompare); // 👈 ENUM COMO OPCIONES
  isAttributeSelectionPhase: boolean = true;
  gameId: number = 1;

  constructor(private router: Router, private roundService: RoundService) {
    const navigation = this.router.getCurrentNavigation();
    const statePlayers = navigation?.extras.state?.['players'];

    if (statePlayers) {
      this.players = statePlayers.map((p: any, index: number) => ({
        name: p.userName,
        id: p.id,
        avatar: `assets/perfiles/perfil${(index % 6) + 1}.png`,
        cards: 8
      }));

      this.emptySlots = Array.from({ length: this.players.length });
      this.battleCards = Array.from({ length: this.players.length }, () => null);
    } else {
      this.router.navigate(['/lobby']);
    }
  }

  ngOnInit(): void {
    this.loadMockCards();
  }

  get currentHand(): PlayerCardDto[] {
    return this.playerHands[this.currentPlayerIndex] || [];
  }

  isCurrentPlayerTurn(): boolean {
    return true; // Cambia esto si implementas autenticación real
  }

  loadMockCards() {
    const totalCards = 56;
    const playersCount = this.players.length;
    const cardsPerPlayer = 8;

    const allCards: PlayerCardDto[] = Array.from({ length: totalCards }, (_, i) => {
      const index = i + 1;
      return {
        isUsed: false,
        userName: `Jugador${i % playersCount}`,
        cardName: `Moto ${index}`,
        cylinderCapacity: Math.floor(Math.random() * 1000),
        hP: Math.floor(Math.random() * 200),
        finalSpeed: Math.floor(Math.random() * 300),
        nOclylinder: Math.floor(Math.random() * 6) + 1,
        weight: Math.floor(Math.random() * 300 + 100),
        torque: Math.floor(Math.random() * 100),
        sinAtributos: `assets/CartasSinAtributos/cartaMoto${index}.0.png`,
        conAtributos: `assets/cartasAtributo/CardMotoA${index}.0.png`
      };
    });

    const shuffled = this.shuffleArray(allCards);
    this.playerHands = Array.from({ length: playersCount }, (_, i) =>
      shuffled.slice(i * cardsPerPlayer, (i + 1) * cardsPerPlayer)
    );
  }

  private shuffleArray<T>(array: T[]): T[] {
    return array
      .map(item => ({ item, sort: Math.random() }))
      .sort((a, b) => a.sort - b.sort)
      .map(({ item }) => item);
  }

  selectCard(index: number) {
    this.selectedCardIndex = index;
    this.selectedModalCard = this.currentHand[index];
    this.isModalVisible = true;
  }

  closeModal() {
    this.isModalVisible = false;
    this.selectedModalCard = null;
  }

  confirmAttributeSelection() {
    if (!this.attributeToCompare) return;
    this.isAttributeSelectionPhase = false;
  }

  launchCard(cardData: PlayerCardDto) {
    this.battleCards[this.currentPlayerIndex] = cardData;

    if (this.selectedCardIndex !== null) {
      this.playerHands[this.currentPlayerIndex].splice(this.selectedCardIndex, 1);
      this.selectedCardIndex = null;
    }

    this.isModalVisible = false;
    this.selectedModalCard = null;

    const allPlayed = this.battleCards.every(card => card !== null);

    if (allPlayed && this.attributeToCompare) {
      this.evaluateRound();
    } else {
      this.advanceTurn();
    }
  }

  evaluateRound() {
    const currentPlayerId = this.players[this.currentPlayerIndex].id;

    this.roundService
      .playTurn(this.gameId, currentPlayerId, this.attributeToCompare!)
      .subscribe({
        next: (result: any) => {
          alert(`🏆 Ganador: ${result.winner?.userName ?? 'Ninguno'}\n📝 ${result.message}`);
          this.resetRound(result.nextPlayer?.userName);
        },
        error: (err) => {
          console.error('❌ Error al evaluar la ronda:', err);
          alert('Error al procesar la ronda. Revisa la consola.');
        }
      });
  }

  resetRound(nextPlayerName: string | null) {
    this.battleCards = Array.from({ length: this.players.length }, () => null);
    this.attributeToCompare = null;

    const index = this.players.findIndex(p => p.name === nextPlayerName);
    this.currentPlayerIndex = index !== -1 ? index : 0;

    this.isAttributeSelectionPhase = true;
  }

  advanceTurn() {
    const totalPlayers = this.players.length;
    this.currentPlayerIndex = (this.currentPlayerIndex + 1) % totalPlayers;
  }
}
