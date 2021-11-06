import { Component, OnInit } from '@angular/core';
import { Horse } from 'src/app/Models/Horse';
import { HorseService } from 'src/app/services/horse.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-horse',
  templateUrl: './horse.component.html',
  styleUrls: ['./horse.component.css']
})
export class HorseComponent implements OnInit {

  public horses: Horse[] = [];

  public id: number;
  public name: string;
  public wins: number;
  public runs: number;
  public about: string;

  public displaySaveButton = true;
  public displayUpdateButton = false;

  constructor(
    private horseService: HorseService,
    private sharedService: SharedService
  ) { }

  ngOnInit(): void {
    this.horseService.getAll().subscribe((data) => {
      this.horses = data;
      this.sharedService.loadHorses(this.horses);
    })
  }

  public createHorse() : void {
    let newHorse: Horse = {
      name: this.name,
      runs: this.runs,
      wins: this.wins,
      about: this.about
    }

    this.horseService.create(newHorse).subscribe((horseWithId) => {
      this.horses.push(horseWithId);
      this.horses.sort((a, b) => (a.name > b.name) ? 1 : -1);
      this.sharedService.loadHorses(this.horses);
      this.name = "";
      this.runs = null;
      this.wins = null;
      this.about = "";
    })
  }

  public deleteHorse(id: number) : void {
    this.horseService.delete(id).subscribe(() => {
      this.horses = this.horses.filter((horse) => {
        return horse.id != id;
      })
      this.sharedService.loadHorses(this.horses);
    })
  }

  public updateHorse(horse: Horse) : void {
    this.displayUpdateButton = true;
    this.displaySaveButton = false;

    this.id = horse.id;
    this.name = horse.name;
    this.runs = horse.runs;
    this.wins = horse.wins;
    this.about = horse.about;
  }

  public saveUpdatedHorseInfo() : void {
    let updatedHorse: Horse = {
      id: this.id,
      name: this.name,
      runs: this.runs,
      wins: this.wins,
      about: this.about
    };

    this.horseService.update(updatedHorse).subscribe(() => {
      this.horses = this.horses.map(horse => horse.id != updatedHorse.id ? horse : updatedHorse);
      this.horses.sort((a, b) => (a.name > b.name) ? 1 : -1);
      this.sharedService.loadHorses(this.horses);

      this.name = "";
      this.runs = null;
      this.wins = null;
      this.about = "";
      this.displayUpdateButton = false;
      this.displaySaveButton = true;
    });

  }

}
