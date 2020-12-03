import { IHealth } from '../../shared/models/health';

export interface IPlayer {
    id: string;
    playerName: string;
    playerHealth: IHealth;
}
