import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
    providedIn: 'root'
})

export class AttackService {
    constructor(private http: HttpClient) { }

    private Url = environment.apiUrl + `/attack`;

    Attack(playerId: number, damage: number, defense: number, tdamage: number, tdefense: number) {
        console.log('target damage: ' + tdamage.toString());
        this.http.get(this.Url + '?playerId=' + playerId + '&damage=' + damage.toString()).subscribe();
    }
}
