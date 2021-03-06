import { AttackPhases } from '../enums/attackPhases';
import { TurnPhases } from '../enums/turnPhases';

export interface ITurn {
    playerId: string;
    phase: TurnPhases;
    attackPhase: AttackPhases;
}
