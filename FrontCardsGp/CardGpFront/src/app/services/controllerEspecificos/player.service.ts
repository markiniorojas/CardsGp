import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiURL } from '../Urlpoint';

@Injectable({ providedIn: 'root' })
export class PlayerService {
  private baseUrl = `${ApiURL}Player`;

  constructor(private http: HttpClient) {}

  getEnabledPlayers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/enabled`);
  }

  enablePlayer(id: number) {
    return this.http.post(`${this.baseUrl}/${id}/enable`, {});
  }

  disablePlayer(id: number) {
    return this.http.post(`${this.baseUrl}/${id}/disable`, {});
  }
}
