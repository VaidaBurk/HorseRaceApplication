import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HorseComponent } from './components/horse/horse.component';
import { BettorComponent } from './components/bettor/bettor.component';

const appRoutes: Routes = [
  { path: 'bettors', component: BettorComponent },
  { path: 'horses', component: HorseComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HorseComponent,
    BettorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],


  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
