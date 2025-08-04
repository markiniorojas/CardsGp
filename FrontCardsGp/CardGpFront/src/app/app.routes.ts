import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'lobby', pathMatch: 'full' },
  { path: 'lobby', loadComponent: () => import('./features/lobby/components/lobby/lobby.component').then(m => m.LobbyComponent) },
//   { path: 'game', loadChildren: () => import('./features/game/game.module').then(m => m.GameModule) },
  { path: '**', redirectTo: 'lobby' }
];