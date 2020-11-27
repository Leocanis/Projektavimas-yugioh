import { ITurn } from './turn';
import { IPlayer } from './player';
import { IField } from '../models/field';
export interface IGame {
    id: string;
    player1: IPlayer;
    player2: IPlayer;
    field1: IField;
    field2: IField;
    turn: ITurn;
}
