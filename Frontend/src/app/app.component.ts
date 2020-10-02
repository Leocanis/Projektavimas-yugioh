import { ICard } from './shared/models/card';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Message } from './shared/models/message';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy, OnInit {
  private playerId: number;

  private card1: ICard;
  private card2: ICard;
  private card3: ICard;
  private card4: ICard;

  constructor() {
  }

  ngOnInit(): void {
    this.card1 = { playerId: 1, attack: 100 };
    this.card2 = { playerId: 2, attack: 150 };
    this.card3 = { playerId: 1, attack: 200 };
    this.card4 = { playerId: 2, attack: 250 };
  }

  ngOnDestroy(): void {
  }

  OnPlayerIdChange(event: any) {
    this.playerId = event.target.value;
    console.log(this.playerId);
  }
}
