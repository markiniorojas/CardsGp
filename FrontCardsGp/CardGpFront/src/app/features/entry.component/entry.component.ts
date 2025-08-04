import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-entry.component',
  imports: [],
  templateUrl: './entry.component.html',
  styleUrl: './entry.component.css'
})
export class EntryComponent {
 constructor(private router: Router) {}

  irAPrincipal() {
    this.router.navigate(['/entry/principal']);
  }
}
