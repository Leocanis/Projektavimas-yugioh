import { Component, Input,  } from '@angular/core';
import { AttackService } from 'src/app/core/services/attack.service';
import { ICard } from 'src/app/shared/models/card';

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
})
export class CardComponent {

    constructor(private attackService: AttackService) { }

    @Input() card: ICard;

    onAttack(): void {
        this.attackService.Attack(this.card.attack);
    }
}
