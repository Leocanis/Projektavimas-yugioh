import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class BattleService {
    
    BattleObserver: boolean;
}


//tried making a global variable to check if a card is attacking
//and would display a target button on the opponent's monsters once it attacked
//but i don't know how to do it