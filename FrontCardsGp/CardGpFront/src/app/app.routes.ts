import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'entry',
        loadComponent: () =>
            import('./features/entry.component/entry.component').then(m => m.EntryComponent),
                children:[
                    {
                        path: 'principal',
                        loadComponent: () =>
                            import('./features/principal.component/principal.component').then(m => m.PrincipalComponent)
                    },
                ]
    }
];

