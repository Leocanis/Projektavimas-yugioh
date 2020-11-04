import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class PlayerturnService {
  constructor(private http: HttpClient) { }

  private Url = `http://localhost:5000/api/turnchange`;
  TurnChange(playerId: number){
    console.log("From \'TurnChange\' method, playerId:"+playerId);
    this.http.get(this.Url + '?playerId=' + playerId).subscribe();
  }
/*
  Attack(playerId: number, damage: number, defense: number, tdamage: number, tdefense: number) {
      console.log("target damage: "+tdamage.toString());
      this.http.get(this.Url + '?playerId=' + playerId + '&damage=' + damage.toString()).subscribe();
  }*/
}
