import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiURL } from '../Urlpoint';

@Injectable({ providedIn: 'root' })
export class CardService {
  private baseUrl = `${ApiURL}Card`;

  constructor(private http: HttpClient) {}

  assignCardsToEnabledPlayers() {
    return this.http.post(`${this.baseUrl}/assign`, {});
  }
}
