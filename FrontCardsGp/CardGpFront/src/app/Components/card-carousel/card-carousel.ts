import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Card } from '../card/card';

@Component({
  selector: 'app-card-carousel',
  standalone : true,
  imports: [CommonModule,Card],
  templateUrl: './card-carousel.html',
  styleUrl: './card-carousel.css'
})
export class CardCarousel {
  @Input() cards: any[] = [];
  @Input() selectedIndex: number | null = null;
  @Output() cardSelected = new EventEmitter<number>();

  onCardClick(index: number) {
    this.cardSelected.emit(index);
  }
}
