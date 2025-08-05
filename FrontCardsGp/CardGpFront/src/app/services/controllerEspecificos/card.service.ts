import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiURL } from '../Urlpoint';
import { PlayerCardDto } from '../../shared/models/PlayerCardDto';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CardService {
  private baseUrl = `${ApiURL}Card`;

  constructor(private http: HttpClient) {}
getCardsByUserName(userName: string): Observable<PlayerCardDto[]> {
  return this.http.get<PlayerCardDto[]>(`${this.baseUrl}/my-cards/${userName}`);
}

}
