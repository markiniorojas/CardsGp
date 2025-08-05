import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-player-panel',
  imports: [CommonModule],
  templateUrl: './player-panel.html',
  styleUrl: './player-panel.css'
})
export class PlayerPanel {
  @Input() name!: string;
  @Input() avatar!: string;
  @Input() cardsCount: number = 8;
  @Input() isCurrent: boolean = false;
}
