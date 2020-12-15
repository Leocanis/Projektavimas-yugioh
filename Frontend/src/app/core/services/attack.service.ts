import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
})

export class AttackService {
    constructor(private http: HttpClient) { }

    private Url = environment.apiUrl + `/attack/attack`;

    Attack(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + '?cardId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId).subscribe();
    }

    Target(gameId: string, playerId: string, cardId: string) {
        this.http.get(this.Url + '?cardId=' + gameId + '&playerId=' + playerId + '&cardId=' + cardId).subscribe();
    }
}
