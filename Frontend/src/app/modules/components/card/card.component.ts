import { TurnPhases } from './../../../shared/enums/turnPhases';
import { BindingFlags } from '@angular/compiler/src/core';
import { IcuPlaceholder } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, Input, OnInit } from '@angular/core';
import { bind } from '@angular/core/src/render3';
import { updateBinding } from '@angular/core/src/render3/instructions';
import { CardTypes } from 'src/app/shared/enums/cardTypes';
import { ITurn } from 'src/app/shared/models/turn';
import { AttackService } from '../../../core/services/attack.service';
import { BattleService } from '../../../core/services/battle.service';
import { PlaycardService } from '../../../core/services/playcard.service';
import { ICard } from '../../../shared/models/card';
import { appConstants } from 'src/app/shared/constants/constants';

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
})
export class CardComponent implements OnInit {

    constructor(private attackService: AttackService, private battleservice: BattleService, private playcardService: PlaycardService) { }

    @Input() i: number;
    @Input() field: string;
    @Input() playerId: number;
    @Input() player: string;
    @Input() card: ICard;
    @Input() turnPhase: ITurn;

    private gameId: string;
    private loggedPlayerId: string;

    ngOnInit(): void {
        this.gameId = sessionStorage.getItem(appConstants.sessionStorageGameId);
        this.loggedPlayerId = sessionStorage.getItem(appConstants.sessionStoragePlayerId);
        console.log(this.player);
        console.log(this.card.playerId);
        console.log(this.loggedPlayerId);
    }

    PlayCard(): void {
        this.playcardService.PlayCard(this.player, this.i, this.playerId);
    }
    Attack(): void {
        this.attackService.Attack(this.gameId, this.loggedPlayerId, this.card.id);
    }
    Target(): void {
        this.attackService.Target(this.gameId, this.loggedPlayerId, this.card.id);
    }
    Cancel(): void {
        this.attackService.Cancel(this.gameId, this.loggedPlayerId, this.card.id);
    }
}
