import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiURL } from '../Urlpoint';
import { AttributeToCompare } from '../../shared/models/AttributeToCompare ';
import { RoundResultDto } from '../../shared/models/RoundResultDto ';


@Injectable({ providedIn: 'root' })
export class RoundService {
  private baseUrl = `${ApiURL}Round`;
  private defaultGameId = 1;

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
