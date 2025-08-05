import { Component, signal, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PlayerService } from '../../services/controllerEspecificos/player.service';
import { CommonModule } from '@angular/common';

interface Player {
  id: number;
  userName: string;
  isEnabled: boolean;
  avatar?: string; 
}

@Component({
  selector: 'app-sala',
  templateUrl: './sala.component.html',
  styleUrls: ['./sala.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class SalaComponent implements OnInit {
  players = signal<Player[]>([]);
  hostId: number = 1;

  constructor(
    private playerService: PlayerService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.hostId = +params['id'] || 1;
      this.loadEnabledPlayers();
    });
  }

  loadEnabledPlayers() {
    this.playerService.getEnabledPlayers().subscribe({
      next: (data: Player[]) => {
        // Agregamos avatar manualmente en frontend
        const withAvatars = data.map(player => ({
          ...player,
          avatar: `/assets/avatar${player.id}.png` // o avatar.png si son iguales
        }));
        this.players.set(withAvatars);
      },
      error: (err) => console.error('Error cargando jugadores habilitados', err)
    });
  }

  addPlayer() {
    const currentIds = this.players().map(p => p.id);
    const nextId = [2, 3, 4, 5, 6, 7, 8].find(id => !currentIds.includes(id));
    if (!nextId) return;

    this.playerService.enablePlayer(nextId).subscribe({
      next: () => this.loadEnabledPlayers(),
      error: (err) => console.error('Error habilitando jugador', err)
    });
  }

  removePlayer(id: number) {
    if (id === this.hostId) return; // no puedes quitar al host

    this.playerService.disablePlayer(id).subscribe({
      next: () => this.loadEnabledPlayers(),
      error: (err) => console.error('Error deshabilitando jugador', err)
    });
  }

  cancel() {
    this.players.set([]);
  }

  saveRoom() {
    console.log('Sala guardada con jugadores:', this.players());
  }
}
