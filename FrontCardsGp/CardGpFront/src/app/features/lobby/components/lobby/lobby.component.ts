import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PRESET_PLAYERS } from '../../../../shared/data/player.config';
import { Player } from '../../../../shared/models/player.model';

@Component({
  selector: 'app-lobby',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './lobby.component.html',
  styleUrl: './lobby.component.css'
})

export class LobbyComponent {
  allPlayers: Player[] = PRESET_PLAYERS;
  activePlayers: Player[] = [];

  readonly MIN_PLAYERS = 2;
  readonly MAX_PLAYERS = 7;

  // Métodos existentes
  activateNextPlayer() {
    const nextPlayer = this.allPlayers.find(
      p => !this.activePlayers.includes(p)
    );
    if (nextPlayer && this.activePlayers.length < this.MAX_PLAYERS) {
      this.activePlayers.push(nextPlayer);
    }
  }

  deactivatePlayer(playerId: number) {
    this.activePlayers = this.activePlayers.filter(p => p.id !== playerId);
  }

  isActive(player: Player): boolean {
    return this.activePlayers.some(p => p.id === player.id);
  }

  // Nuevos métodos para la interfaz mejorada
  togglePlayer(player: Player) {
    if (this.isActive(player)) {
      this.deactivatePlayer(player.id);
    } else if (this.activePlayers.length < this.MAX_PLAYERS) {
      this.activePlayers.push(player);
    }
  }

  getAvailablePlayers(): Player[] {
    return this.allPlayers.filter(p => !this.isActive(p));
  }

  addRandomPlayer() {
    const availablePlayers = this.getAvailablePlayers();
    if (availablePlayers.length > 0 && this.activePlayers.length < this.MAX_PLAYERS) {
      const randomIndex = Math.floor(Math.random() * availablePlayers.length);
      const randomPlayer = availablePlayers[randomIndex];
      this.activePlayers.push(randomPlayer);
    }
  }

  clearAllPlayers() {
    this.activePlayers = [];
  }

  canStartGame(): boolean {
    return this.activePlayers.length >= this.MIN_PLAYERS &&
           this.activePlayers.length <= this.MAX_PLAYERS;
  }

  startGame() {
    if (this.canStartGame()) {
      console.log('Iniciando juego con jugadores:', this.activePlayers);
      // Aquí se implementaría la lógica para iniciar el juego
      alert(`¡Iniciando juego con ${this.activePlayers.length} jugadores!`);
    }
  }

  getStatusClass(): string {
    const count = this.activePlayers.length;
    if (count < this.MIN_PLAYERS) return 'status-insufficient';
    if (count >= this.MIN_PLAYERS && count <= this.MAX_PLAYERS) return 'status-ready';
    return 'status-full';
  }

  getStatusMessage(): string {
    const count = this.activePlayers.length;
    if (count === 0) return 'Sin jugadores';
    if (count < this.MIN_PLAYERS) return `Faltan ${this.MIN_PLAYERS - count} jugadores`;
    if (count >= this.MIN_PLAYERS && count <= this.MAX_PLAYERS) return '¡Listo para jugar!';
    return 'Sala llena';
  }

  getStartButtonText(): string {
    if (this.canStartGame()) {
      return `Iniciar Juego (${this.activePlayers.length} jugadores)`;
    }
    return 'Iniciar Juego';
  }

  getStartHint(): string {
    const count = this.activePlayers.length;
    if (count === 0) return 'Agrega al menos 2 jugadores para comenzar';
    if (count < this.MIN_PLAYERS) return `Necesitas ${this.MIN_PLAYERS - count} jugador(es) más`;
    return '';
  }
}

