import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
})

export class AttackService {
    constructor(private http: HttpClient) { }

    private Url = environment.apiUrl + `/attack`;

    Attack(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + 'attack?cardId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId).subscribe();
    }

    Target(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + 'target?cardId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId).subscribe();
    }

    Cancel(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + 'cancel?cardId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId).subscribe();
    }
}
