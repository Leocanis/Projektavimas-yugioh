import { GameService } from './../../../core/services/game.service';
import { ICard } from '../../../shared/models/card';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BattleService } from '../../../core/services/battle.service';
import { PlayerturnService } from '../../../core/services/playerturn.service';
import { Subscription } from 'rxjs';
import { GameHubService } from 'src/app/core/hubs/game.hub.service';
import { IGame } from 'src/app/shared/models/game';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnDestroy, OnInit {
  private gameHubSubscription: Subscription;
  private game: IGame;

  constructor(
    private gameHubService: GameHubService,
    private battleservice: BattleService,
    private playerturnservice: PlayerturnService,
    private gameSerive: GameService
  ) {
    this.gameHubSubscription = this.gameHubService.getGame().subscribe(
      (game) => {
        this.game = game;
        console.log(this.game);
      });
  }

  private card1: ICard;
  private card2: ICard;
  private card3: ICard;
  private card4: ICard;

  ngOnInit(): void {
    this.gameSerive.getGame(sessionStorage.getItem('gameId')).subscribe({
      next: game => {
        this.game = game;
      }
    });

    this.battleservice.BattleObserver = false;
    this.card1 = {
      playerId: 1, name: 'Dark Magician',
      attack: 2500, defense: 2100, attacking: false, img: '../assets/CardImages/dark_magician.jpg'
    };
    this.card2 = {
      playerId: 2, name: 'Blue-eyes White Dragon',
      attack: 3000, defense: 2500, attacking: false, img: '../assets/CardImages/blue_eyes_white_dragon.jpg'
    };
    this.card3 = {
      playerId: 1, name: 'Celtic Guardian',
      attack: 1400, defense: 1200, attacking: false, img: '../assets/CardImages/celtic_guardian.jpg'
    };
    this.card4 = {
      playerId: 2, name: 'Vorse Raider',
      attack: 1900, defense: 1200, attacking: false, img: '../assets/CardImages/vorse_raider.jpg'
    };
  }

  ngOnDestroy(): void {
  }

  mainPhaseClick(): void {

  }

  attackPhaseClick(): void {

  }

  secondPhaseClick(): void {

  }

  endTurnClick(): void {

  }
}
