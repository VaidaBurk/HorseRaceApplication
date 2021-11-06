import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Horse } from '../Models/Horse';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private availableHorses = new BehaviorSubject<Horse[]>(null);

  constructor() { }

  loadHorses(horses: Horse[]) {
    this.availableHorses.next(horses);
  }

  getHorses() : Observable<Horse[]> {
    return this.availableHorses.asObservable();
  }
}
