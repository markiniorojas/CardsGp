// card-modal.component.ts
import { CommonModule } from '@angular/common';
import { Component, Input, Output, EventEmitter } from '@angular/core';

export interface CardData {
  image: string;
  detailedImage: string;
  name?: string;
  brand?: string;
 
}

@Component({
  selector: 'app-card-modal',
  imports: [CommonModule],
  templateUrl: './card-modal.html',
  styleUrl: './card-modal.css'
})
export class CardModal {
 @Input() isVisible: boolean = false;
  @Input() cardData: CardData | null = null;
  @Output() close = new EventEmitter<void>();
  @Output() cardLaunched = new EventEmitter<CardData>();

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
