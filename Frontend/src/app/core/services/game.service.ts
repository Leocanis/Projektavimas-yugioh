import { IGame } from './../../shared/models/game';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class GameService {
    constructor(private http: HttpClient) { }

    private Url = environment.apiUrl + `/game/getGame`;

    getGame(gameId: string): Observable<IGame> {
        const res = this.http.get<IGame>(this.Url + '?gameId=' + gameId)
            .pipe(
                tap(data => { }));

        return res;
    }
}