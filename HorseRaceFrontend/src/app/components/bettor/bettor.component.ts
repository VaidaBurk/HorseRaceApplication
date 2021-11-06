import { Component, OnInit } from '@angular/core';
import { Bettor } from 'src/app/Models/Bettor';
import { Horse } from 'src/app/Models/Horse';
import { BettorService } from 'src/app/services/bettor.service';
import { HorseService } from 'src/app/services/horse.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-bettor',
  templateUrl: './bettor.component.html',
  styleUrls: ['./bettor.component.css']
})
export class BettorComponent implements OnInit {

  public bettors: Bettor[] = [];
  public horses: Horse[] = [];

  public id: number;
  public firstName: string;
  public lastName: string;
  public bet: number;
  public horseId: number = 0;

  public filterHorseId: number = 0;

  public displaySaveButton = true;
  public displayUpdateButton = false;

  constructor (
    private bettorService: BettorService,
    private sharedService: SharedService
  ) { }

  ngOnInit(): void {
    this.bettorService.getAll().subscribe((data) => {
      this.bettors = data;
    })
    this.sharedService.getHorses().subscribe((horses) => {
      this.horses = horses;
    })
  }

  public addBettor() : void {
    let newBettor: Bettor = {
      firstName: this.firstName,
      lastName: this.lastName,
      bet: this.bet,
      horseId: this.horseId
    }

    this.bettorService.create(newBettor).subscribe((bettorWithId) => {
      this.bettors.push(bettorWithId);
      this.firstName = "";
      this.lastName = "";
      this.bet = null;
      this.horseId = null;
    });
  }

  public deleteBettor(id: number) : void {
    this.bettorService.delete(id).subscribe(() => {
      this.bettors = this.bettors.filter((bettor) => {
        return bettor.id != id;
      })
    })
  }

  public updateBettor(bettor: Bettor) : void {
    this.id = bettor.id;
    this.firstName = bettor.firstName;
    this.lastName = bettor.lastName;
    this.bet = bettor.bet;
    this.horseId = bettor.horseId;

    this.displayUpdateButton = true;
    this.displaySaveButton = false;
  }

  public saveUpdatedBettorInfo() : void {
    let updatedBettor: Bettor = {
      id: this.id,
      firstName: this.firstName,
      lastName: this.lastName,
      bet: this.bet,
      horseId: this.horseId
    }
    this.bettorService.update(updatedBettor).subscribe((bettorForRendering) => {      
      this.bettors = this.bettors.map(b => b.id != updatedBettor.id ? b : bettorForRendering);
      this.bettors.sort((a, b) => (a.bet < b.bet) ? 1 : -1);

      this.firstName = "";
      this.lastName = "";
      this.bet = null;
      this.horseId = null;

      this.displayUpdateButton = false;
      this.displaySaveButton = true;
    })
  }

  public filterByHorseId(filterHorseId: number) : void {
    this.bettorService.filterByHorseId(filterHorseId).subscribe((data) => {
      this.bettors = data;
    })
  }

}
