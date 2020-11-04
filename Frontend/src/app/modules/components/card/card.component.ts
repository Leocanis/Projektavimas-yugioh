import { Component, Input,  } from '@angular/core';
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
    target: ICard;

    Target(): void{
        this.target = this.card;
        console.log("Targeting: "+this.target.name);
        
    }
    onAttack(): void {
        console.log('from \'onAttack\' Method');
        this.card.attacking = true;
        this.battleservice.BattleObserver = true;
        this.attackService.Attack(this.card.playerId, this.card.attack);
    }
}
