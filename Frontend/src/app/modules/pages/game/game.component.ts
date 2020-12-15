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
  private numinrow = [0, 1, 2, 3, 4, 5];
  private playerId: number;
  private fieldtype: string;
  private f: number;
  private hand = 'hand';
  private spell = 'spell';
  private monster = 'monster';

  constructor(
    private gameHubService: GameHubService,
    private battleservice: BattleService,
    private turnservice: TurnService,
    private gameSerive: GameService
  ) {
    this.gameHubSubscription = this.gameHubService.getGame().subscribe(
      (game) => {
        this.game = game;

        console.log(game.field1);
        console.log(game.field2);
        console.log(game.turn.playerId);
        if (game.turn.playerId === game.player1.id) {
          this.playerId = 1;
        }
        if (game.turn.playerId === game.player2.id) {
          this.playerId = 2;
        }
        console.log('player id:' + this.playerId);
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
        console.log(game);
        this.game = game;
        this.checkTurnPhase();
      }
    });
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
