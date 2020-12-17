import { CardTypes } from '../enums/cardTypes';

export interface ICard {
    id: string;
    playerId: number;
    name: string;
    attack: number;
    defense: number;
    img: string;
    attacked: boolean;
    type: CardTypes;
}
