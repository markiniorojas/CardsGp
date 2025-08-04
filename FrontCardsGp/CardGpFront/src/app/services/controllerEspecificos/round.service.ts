import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiURL } from '../Urlpoint';

@Injectable({ providedIn: 'root' })
export class RoundService {
  private baseUrl = `${ApiURL}Round`;

  constructor(private http: HttpClient) {}

  playTurn(gameId: number, currentPlayerId: number, attribute: string) {
    return this.http.post(`${this.baseUrl}/${gameId}/play-turn`, null, {
      params: {
        currentPlayerId,
        attribute
      }
    });
  }
}
