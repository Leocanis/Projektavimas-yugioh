import { IHealth } from 'src/app/shared/models/health';

export interface IPlayer {
    id: string;
    playerName: string;
    playerHealth: IHealth;
}
