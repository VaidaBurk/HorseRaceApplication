import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Horse } from '../Models/Horse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HorseService {

  constructor(private http: HttpClient) { 
  }

  public getAll(): Observable<Horse[]>{
    return this.http.get<Horse[]>('https://localhost:44340/Horse');
  }

  public delete(id: number): Observable<Horse> {
    return this.http.delete<Horse>(`https://localhost:44340/Horse/${id}`);
  }

  public create(horse: Horse): Observable<Horse> {
    return this.http.post<Horse>('https://localhost:44340/Horse', horse);
  }

  public update(horse: Horse): Observable<Horse> {
    return this.http.put<Horse>(`https://localhost:44340/Horse/${horse.id}`, horse);
  }
}
