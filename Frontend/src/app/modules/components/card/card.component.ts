import { BindingFlags } from '@angular/compiler/src/core';
import { IcuPlaceholder } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, Input,  } from '@angular/core';
import { bind } from '@angular/core/src/render3';
import { updateBinding } from '@angular/core/src/render3/instructions';
import { AttackService } from '../../../core/services/attack.service';
import { BattleService } from '../../../core/services/battle.service';
import { PlaycardService } from '../../../core/services/playcard.service';
import { ICard } from '../../../shared/models/card';

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
})
export class CardComponent {

    constructor(private attackService: AttackService, private battleservice: BattleService, private playcardService: PlaycardService) { }

    @Input() i:number
    @Input() fieldtype: string;
    @Input() playerId: number;
    @Input() player: string;
    @Input() card: ICard;
    @Input() target: ICard = { playerId: 0, name: "", attack: 0, defense: 0, attacking: false, img: ""};//does not update

    PlayCard(): void{
        //console.log("playcard index: "+this.i);
        //console.log("playcard player: "+this.player);
        console.log("playcard playerindex: "+this.playerId);
        this.playcardService.PlayCard(this.player,this.i,this.playerId);
    }
    Target(): void{
        console.log("target");
        console.log(this.card.playerId);

        console.log("Targeting: "+this.target.name);
        console.log("Target stats:");
        console.log("Damage:" +this.target.attack);
        
    }
    onAttack(): void {
        console.log('from \'onAttack\' Method');
        console.log('player in attack id:'+this.card.playerId);
        
        this.card.attacking = true;
        this.battleservice.BattleObserver = true;
        this.attackService.Attack(this.card.playerId, this.card.attack, this.card.defense, this.target.attack, this.target.defense);
    }
}
