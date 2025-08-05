import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PlayerService } from '../../services/controllerEspecificos/player.service';

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css'],
  standalone: true,
  imports: []
})
export class PrincipalComponent {

  constructor(private router: Router) {}

  irAPrincipal() {
    this.router.navigate(['/lobby']);
  }
  // constructor(
  //   private playerService: PlayerService,
  //   private router: Router
  // ) {}

  // crearSala() {
  //   const hostId = 1;

  //   this.playerService.enablePlayer(hostId).subscribe({
  //     next: () => {
  //      this.router.navigate(['/entry/sala', hostId]);
  //     },
  //     error: (err) => {
  //       console.error('Error habilitando jugador 1:', err);
  //     }
  //   });
  // }
}
