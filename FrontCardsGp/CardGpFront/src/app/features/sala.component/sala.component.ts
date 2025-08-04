import { Component, signal } from '@angular/core';
// import { PlayerService } from '/services/player.service';

interface Player {
  id: number;
  name: string;
  avatar: string; // URL o base64
}

@Component({
  selector: 'app-sala.component',
  imports: [],
  templateUrl: './sala.component.html',
  styleUrl: './sala.component.css'
})
export class SalaComponent {
   // ✅ Lista de jugadores usando Signals
  players = signal<Player[]>([]);

  // constructor(private playerService: PlayerService) {}

  // 👉 Simular agregar jugador (puedes reemplazar con datos de backend)
  addPlayer() {
    const newPlayer: Player = {
      id: Date.now(),
      name: `Jugador ${this.players().length + 1}`,
      avatar: '/assets/avatar.png'
    };
    this.players.update(p => [...p, newPlayer]);
  }

  // 👉 Eliminar jugador
  removePlayer(id: number) {
    this.players.update(p => p.filter(player => player.id !== id));
  }

  // 👉 Conectar con backend
  // saveRoom() {
  //   // this.playerService.savePlayers(this.players()).subscribe({
  //     next: (res) => console.log('Sala guardada:', res),
  //     error: (err) => console.error(err)
  //   });
  // }

  cancel() {
    this.players.set([]); // Limpia la sala
  }
}
