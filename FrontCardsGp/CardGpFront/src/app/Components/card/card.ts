import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-card',
  imports: [CommonModule],
  templateUrl: './card.html',
  styleUrl: './card.css'
})
export class Card {
  @Input() card!: any;
  @Input() selected: boolean = false;
  @Output() select = new EventEmitter<void>();

  onSelectCard() {
    this.select.emit();
  }
}
