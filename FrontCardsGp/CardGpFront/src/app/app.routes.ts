import { Routes } from '@angular/router';

export const routes: Routes = [
  
  { path: '', redirectTo: 'entry', pathMatch: 'full' },

//   { path: 'game', loadChildren: () => import('./features/game/game.module').then(m => m.GameModule) },
  {
    path: 'entry', loadComponent: () =>
      import('./features/entry.component/entry.component').then(m => m.EntryComponent)
  },

  {
    path: 'principal', loadComponent: () =>
      import('./features/principal.component/principal.component').then(m =>m.PrincipalComponent)
  },
                                  
  { path: 'lobby', loadComponent: () => 
    import('./features/lobby/components/lobby/lobby.component').then(m => m.LobbyComponent) 
  },
  {path: 'partida', loadComponent: () =>
    import('./Components/board/board').then(m => m.Board)
  },

  {path: 'panel', loadComponent: () =>
    import('./Components/player-panel/player-panel').then(m => m.PlayerPanel)
  },

  { path: '**', redirectTo: 'entry'}

];
// <<<<<<< HEAD
//   {
//     path: 'entry',
//     loadComponent: () =>
//       import('./features/entry.component/entry.component').then(m => m.EntryComponent),
//     children: [
//       {
//         path: 'principal',
//         loadComponent: () =>
//           import('./features/principal.component/principal.component').then(m => m.PrincipalComponent)
//       },
//       {
//         path: 'sala/:id',
//         loadComponent: () =>
//           import('./features/sala.component/sala.component').then(m => m.SalaComponent)
//       },
//       {
//         path: 'juego',
//         loadComponent: () =>
//           import('./juego/juego').then(m => m.Juego) // Asegúrate que así se exporta
//       },
//       {
//         path: '',
//         redirectTo: 'principal',
//         pathMatch: 'full'
//       }
//     ]
//   },
//   {
//     path: '',
//     redirectTo: 'entry',
//     pathMatch: 'full'
//   },
//   {
//     path: '**',
//     redirectTo: 'entry'
//   }
// ];

  

