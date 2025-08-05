import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiURL } from '../Urlpoint';

@Injectable({ providedIn: 'root' })
export class GenericApiService<TDto> {
  constructor(private http: HttpClient) {}

  getAll(endpoint: string): Observable<TDto[]> {
    return this.http.get<TDto[]>(`${ApiURL}${endpoint}`);
  }

  getById(endpoint: string, id: number): Observable<TDto> {
    return this.http.get<TDto>(`${ApiURL}${endpoint}/${id}`);
  }

  create(endpoint: string, dto: TDto): Observable<TDto> {
    return this.http.post<TDto>(`${ApiURL}${endpoint}`, dto);
  }

  delete(endpoint: string, id: number): Observable<void> {
    return this.http.delete<void>(`${ApiURL}${endpoint}/${id}`);
  }
}
