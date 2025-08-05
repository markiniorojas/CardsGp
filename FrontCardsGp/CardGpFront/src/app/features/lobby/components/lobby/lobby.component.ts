import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { Player } from '../../../../shared/models/player.model';
import { PlayerService } from '../../../../services/controllerEspecificos/player.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lobby',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './lobby.component.html',
  styleUrl: './lobby.component.css'
})
export class LobbyComponent implements OnInit {
  enabledPlayers: Player[] = [];

  constructor(private playerService: PlayerService, private router : Router) {}

  ngOnInit(): void {
    this.loadEnabledPlayers();
  }

  startGame(): void {
  if (this.enabledPlayers.length >= 2) {
    this.router.navigate(['/partida'], {
      state: { players: this.enabledPlayers }
    });
  }
}

  loadEnabledPlayers(): void {
    this.playerService.getEnabledPlayers().subscribe((players) => {
      this.enabledPlayers = players;
    });
  }

  enablePlayersFrom2To8(): void {
    const enabledIds = this.enabledPlayers.map(p => p.id);

    for (let id = 2; id <= 8; id++) {
      if (!enabledIds.includes(id)) {
        this.playerService.enablePlayer(id).subscribe({
          next: () => console.log(`Jugador ${id} habilitado.`),
          error: (err) => console.error(`Error al habilitar jugador ${id}`, err),
          complete: () => this.loadEnabledPlayers()
        });
      }
    }
  }

  disableAllExceptPlayer1(): void {
    const playersToDisable = this.enabledPlayers.filter(player => player.id !== 1);

    playersToDisable.forEach(player => {
      this.playerService.disablePlayer(player.id).subscribe({
        next: () => console.log(`Jugador ${player.id} deshabilitado.`),
        error: (err) => console.error(`Error al deshabilitar jugador ${player.id}`, err),
        complete: () => this.loadEnabledPlayers()
      });
    });
  }

  onPlayerClick(player: Player): void {
    if (player.id === 1) {
      console.log('El jugador 1 no se puede deshabilitar.');
      return;
    }

    this.playerService.disablePlayer(player.id).subscribe({
      next: () => console.log(`Jugador ${player.id} deshabilitado.`),
      error: (err) => console.error(`Error al deshabilitar jugador ${player.id}`, err),
      complete: () => this.loadEnabledPlayers()
    });
  }
}
