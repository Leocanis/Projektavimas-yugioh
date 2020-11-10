import { ICard } from '../../../shared/models/card';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BattleService } from '../../../core/services/battle.service';
import { PlayerturnService } from '../../../core/services/playerturn.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnDestroy, OnInit {
  private playerId: number;

  private card1: ICard;
  private card2: ICard;
  private card3: ICard;
  private card4: ICard;

  constructor (private battleservice: BattleService, private playerturnservice: PlayerturnService) { }

  ngOnInit(): void {
    this.battleservice.BattleObserver = false;
    this.card1 = { playerId: 1, name: 'Dark Magician',
    attack: 2500, defense: 2100, attacking: false, img: '../assets/CardImages/dark_magician.jpg'};
    this.card2 = { playerId: 2, name: 'Blue-eyes White Dragon',
    attack: 3000, defense: 2500, attacking: false, img: '../assets/CardImages/blue_eyes_white_dragon.jpg'};
    this.card3 = { playerId: 1, name: 'Celtic Guardian',
    attack: 1400, defense: 1200, attacking: false, img: '../assets/CardImages/celtic_guardian.jpg'};
    this.card4 = { playerId: 2, name: 'Vorse Raider',
    attack: 1900, defense: 1200, attacking: false, img: '../assets/CardImages/vorse_raider.jpg'};
  }

  ngOnDestroy(): void {
  }

  OnPlayerIdChange(event: any) {
    this.playerId = event.target.value;
    console.log(this.playerId);
    this.playerturnservice.TurnChange(this.playerId);
  }
}
