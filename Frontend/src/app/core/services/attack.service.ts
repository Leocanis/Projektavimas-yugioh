import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class AttackService {
    constructor(private http: HttpClient) { }

    private Url = `http://localhost:5000/api/attack`;

    Attack(playerId: number, damage: number, defense: number, tdamage: number, tdefense: number) {

        this.http.get(this.Url + '?playerId=' + playerId + '&damage=' + damage.toString()).subscribe();
    }
}
