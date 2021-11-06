import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bettor } from '../Models/Bettor';

@Injectable({
  providedIn: 'root'
})
export class BettorService {

  constructor(
    private http: HttpClient
  ) { }

  public getAll(): Observable<Bettor[]>{
    return this.http.get<Bettor[]>('https://localhost:44340/Bettor');
  }

  public delete(id: number): Observable<Bettor> {
    return this.http.delete<Bettor>(`https://localhost:44340/Bettor/${id}`);
  }

  public create(bettor: Bettor): Observable<Bettor> {
    return this.http.post<Bettor>('https://localhost:44340/Bettor', bettor);
  }

  public update(bettor: Bettor): Observable<Bettor> {
    return this.http.put<Bettor>(`https://localhost:44340/Bettor/${bettor.id}`, bettor);
  }

  public filterByHorseId(horseId: number): Observable<Bettor[]> {
    return this.http.get<Bettor[]>(`https://localhost:44340/Bettor/Horse/${horseId}`);
  }
}
