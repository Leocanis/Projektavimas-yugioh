import { TurnPhases } from './../../../shared/enums/turnPhases';
import { GameService } from './../../../core/services/game.service';
import { ICard } from '../../../shared/models/card';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { BattleService } from '../../../core/services/battle.service';
import { TurnService } from '../../../core/services/turn.service';
import { Subscription } from 'rxjs';
import { GameHubService } from '../../../core/hubs/game.hub.service';
import { IGame } from '../../../shared/models/game';
import { appConstants } from '../../../shared/constants/constants';

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
    private turnservice: TurnService,
    private gameSerive: GameService
  ) {
    this.gameHubSubscription = this.gameHubService.getGame().subscribe(
      (game) => {
        this.game = game;
        console.log('in game===========');
        console.log(game.field1);
        
        this.checkTurnPhase();
      });
  }

  private card1: ICard;
  private card2: ICard;
  private card3: ICard;
  private card4: ICard;
  private card5: ICard;
  private card6: ICard;

  private toggleMainPhaseButton = true;
  private toggleAttackPhaseButton = true;
  private toggleSecondPhaseButton = true;
  private toggleEndTurnButton = true;

  private turn = 0;

  ngOnInit(): void {
    this.gameSerive.getGame(sessionStorage.getItem(appConstants.sessionStorageGameId)).subscribe({
      next: game => {
        this.game = game;
        this.checkTurnPhase();
      }
    });

    // this.battleservice.BattleObserver = false;
    // this.card1 = {
    //   playerId: 1, name: 'Dark Magician',
    //   attack: 2500, defense: 2100, attacking: false, img: '../assets/CardImages/dark_magician.jpg'
    // };
    // this.card2 = {
    //   playerId: 2, name: 'Blue-eyes White Dragon',
    //   attack: 3000, defense: 2500, attacking: false, img: '../assets/CardImages/blue_eyes_white_dragon.jpg'
    // };
    // this.card3 = {
    //   playerId: 1, name: 'Celtic Guardian',
    //   attack: 1400, defense: 1200, attacking: false, img: '../assets/CardImages/celtic_guardian.jpg'
    // };
    // this.card4 = {
    //   playerId: 2, name: 'Vorse Raider',
    //   attack: 1900, defense: 1200, attacking: false, img: '../assets/CardImages/vorse_raider.jpg'
    // };
  }

  ngOnDestroy(): void {
  }

  attackPhaseClick(): void {
    this.turnservice.attackPhase();
  }

  secondPhaseClick(): void {
    this.turnservice.secondPhase();
  }

  endTurnClick(): void {
    this.turnservice.endTurn();
  }

  forward(): void {

  }

  back(): void {

  }

  checkTurnPhase(): void {
    if (this.game.turn && this.game.turn.playerId) {
      this.turn = this.game.turn.phase;
      if (this.game.turn.playerId !== sessionStorage.getItem(appConstants.sessionStoragePlayerId)) {
        this.toggleMainPhaseButton = true;
        this.toggleAttackPhaseButton = true;
        this.toggleSecondPhaseButton = true;
        this.toggleEndTurnButton = true;
      } else {
        if (this.game.turn.phase === TurnPhases.MainPhase) {
          this.toggleMainPhaseButton = true;
          this.toggleAttackPhaseButton = false;
          this.toggleSecondPhaseButton = false;
          this.toggleEndTurnButton = false;
        } else if (this.game.turn.phase === TurnPhases.AttackPhase) {
          this.toggleMainPhaseButton = true;
          this.toggleAttackPhaseButton = true;
          this.toggleSecondPhaseButton = false;
          this.toggleEndTurnButton = false;
        } else if (this.game.turn.phase === TurnPhases.SecondPhase) {
          this.toggleMainPhaseButton = true;
          this.toggleAttackPhaseButton = true;
          this.toggleSecondPhaseButton = true;
          this.toggleEndTurnButton = false;
        }
      }
    }
  }
}
