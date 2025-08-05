import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiURL } from '../Urlpoint';
import { PlayerCardDto } from '../../shared/models/PlayerCardDto';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CardService {
  private baseUrl = `${ApiURL}Card`;

  constructor(private http: HttpClient) {}

  // ✅ Asignar 8 cartas a cada jugador habilitado
  assignCardsToEnabledPlayers(): Observable<string> {
    return this.http.post(`${this.baseUrl}/assign`, null, { responseType: 'text' });
  }

}
