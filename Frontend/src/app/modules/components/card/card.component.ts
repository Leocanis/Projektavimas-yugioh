import { Component, Input,  } from '@angular/core';
import { AttackService } from 'src/app/core/services/attack.service';
import { BattleService } from 'src/app/core/services/battle.service';
import { ICard } from 'src/app/shared/models/card';

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
})
export class CardComponent {

    constructor(private attackService: AttackService, private battleservice: BattleService) { }

    @Input() playerId: number;
    @Input() card: ICard;

    onAttack(): void {
        this.card.attacking = true;
        this.battleservice.BattleObserver = true;
        this.attackService.Attack(this.card.playerId, this.card.attack);
    }
}
