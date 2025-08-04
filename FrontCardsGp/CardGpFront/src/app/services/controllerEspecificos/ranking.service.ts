import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiURL } from '../Urlpoint';

@Injectable({ providedIn: 'root' })
export class RankingService {
  private baseUrl = `${ApiURL}Ranking`;

  constructor(private http: HttpClient) {}

  getTop3Players(gameId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/${gameId}/top3`);
  }
}
