import { ITurn } from './turn';
import { IPlayer } from './player';

export interface IGame {
    id: string;
    player1: IPlayer;
    player2: IPlayer;
    turn: ITurn;
}
