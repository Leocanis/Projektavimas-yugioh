import { CardAttackPhase } from '../enums/cardAttackPhase';
import { CardTypes } from '../enums/cardTypes';

export interface ICard {
    id: string;
    playerId: number;
    name: string;
    attack: number;
    defense: number;
    img: string;
    imgBytes: string;
    attacked: boolean;
    type: CardTypes;
    attackPhase: CardAttackPhase;
}
