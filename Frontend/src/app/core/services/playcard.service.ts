import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class PlaycardService {
  constructor(private http: HttpClient) { }

  private Url = environment.apiUrl + `/playcard`;
  PlayCard(player: string, index: number, playerindex: number) {
    this.http.get(this.Url + '?player=' + player + '&index=' + index.toString() + '&playerindex=' + playerindex.toString()).subscribe();
  }

  Attack(playerId: number, damage: number, defense: number, tdamage: number, tdefense: number) {
    this.http.get(this.Url + '?playerId=' + playerId + '&damage=' + damage.toString()).subscribe();
  }

}
