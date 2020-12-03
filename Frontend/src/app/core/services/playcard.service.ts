import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class PlaycardService {
  constructor(private http: HttpClient) { }

  private Url = environment.apiUrl + `/playcard`;
  ///private Url = environment.apiUrl + `/attack`;
  PlayCard(player: string, index:number, playerindex:number) {
      this.http.get(this.Url + '?player=' + player + '&index=' + index.toString()+ '&playerindex=' + playerindex.toString()).subscribe();
      //this.http.get(this.Url + '?playerId=' + 1 + '&damage=' + 0).subscribe();
  }
  
  Attack(playerId: number, damage: number, defense: number, tdamage: number, tdefense: number) {
        //console.log('target damage: ' + tdamage.toString());
        this.http.get(this.Url + '?playerId=' + playerId + '&damage=' + damage.toString()).subscribe();
    }
  
}
