import { BindingFlags } from '@angular/compiler/src/core';
import { IcuPlaceholder } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, Input,  } from '@angular/core';
import { bind } from '@angular/core/src/render3';
import { updateBinding } from '@angular/core/src/render3/instructions';
import { AttackService } from '../../../core/services/attack.service';
import { BattleService } from '../../../core/services/battle.service';
import { ICard } from '../../../shared/models/card';

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
})
export class CardComponent {

    constructor(private attackService: AttackService, private battleservice: BattleService) { }

    @Input() playerId: number;
    @Input() card: ICard;
    @Input() target: ICard = { playerId: 0, name: "", attack: 0, defense: 0, attacking: false, img: ""};//does not update

    Target(): void{
        //console.log("here");
        
        this.target = {playerId:this.card.playerId, attack:this.card.attack, defense:this.card.defense, 
            img:this.card.img, name:this.card.name,attacking:this.card.attacking};
        
        //this.target.attack = this.card.attack;
        //this.target.defense = this.card.defense;
        //this.target.img = this.card.img;
        //this.target.name = this.card.name;
        //this.target.playerId = this.card.playerId;
        
        //target:this.card;
        //this.target = this.card;
        console.log("Targeting: "+this.target.name);
        console.log("Target stats:");
        console.log("Damage:" +this.target.attack);
        
    }
    onAttack(): void {
        console.log('from \'onAttack\' Method');
        console.log("Targeting: "+this.target.name);
        console.log("Target\'s owner: "+this.target.playerId);
        this.card.attacking = true;
        this.battleservice.BattleObserver = true;
        this.attackService.Attack(this.card.playerId, this.card.attack, this.card.defense, this.target.attack, this.target.defense);
    }
}
