import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class AttackService {
    constructor(private http: HttpClient) { }

    private Url = `http://localhost:5000/api/attack`;

    Attack(damage: number) {

        this.http.get(this.Url + '?damage=' + damage.toString()).subscribe();
    }
}
