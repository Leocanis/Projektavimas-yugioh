import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
})

export class AttackService {
    constructor(private http: HttpClient) { }

    private Url = environment.apiUrl + `/attack/`;

    Attack(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + 'action?gameId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId + '&state=1').subscribe();
    }

    Target(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + 'action?gameId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId + '&state=2').subscribe();
    }

    Cancel(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + 'action?gameId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId + '&state=3').subscribe();
    }
}
