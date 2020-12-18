import { ITurn } from './turn';
import { IPlayer } from './player';
import { IField } from './field';
import { AttackPhases } from '../enums/attackPhases';
import { GameTypes } from '../enums/gameTypes';

export interface IGame {
    id: string;
    player1: IPlayer;
    player2: IPlayer;
    field1: IField;
    field2: IField;
    turn: ITurn;
    gameType: GameTypes;
}
