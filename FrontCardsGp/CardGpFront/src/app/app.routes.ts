import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'entry',
    loadComponent: () =>
      import('./features/entry.component/entry.component').then(m => m.EntryComponent),
    children: [
      {
        path: 'principal',
        loadComponent: () =>
          import('./features/principal.component/principal.component').then(m => m.PrincipalComponent)
      },
      {
        path: 'sala/:id',
        loadComponent: () =>
          import('./features/sala.component/sala.component').then(m => m.SalaComponent)
      },
      {
        path: 'juego',
        loadComponent: () =>
          import('./juego/juego').then(m => m.Juego) // ✅ Asegúrate que así se exporta
      },
      {
        path: '',
        redirectTo: 'principal',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    redirectTo: 'entry',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: 'entry'
  }
];
