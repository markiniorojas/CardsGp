import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayerCardDto } from '../shared/models/PlayerCardDto';

@Component({
  selector: 'app-card-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './card-modal.html',
  styleUrl: './card-modal.css'
})
export class CardModal {
  @Input() isVisible: boolean = false;
  @Input() cardData: PlayerCardDto | null = null;

  @Output() close = new EventEmitter<void>();
  @Output() cardLaunched = new EventEmitter<PlayerCardDto>();

  closeModal() {
    this.close.emit();
  }

  launchCard() {
    if (this.cardData) {
      this.cardLaunched.emit(this.cardData);
      this.closeModal();
    }
  }
}
