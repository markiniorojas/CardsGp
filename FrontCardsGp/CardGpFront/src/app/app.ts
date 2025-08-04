import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Board } from './Components/board/board';
import { MatIconModule } from '@angular/material/icon';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,Board, MatIconModule],


  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('CardGpFront');
}
