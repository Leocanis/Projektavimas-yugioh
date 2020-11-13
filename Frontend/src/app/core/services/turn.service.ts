import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { appConstants } from 'src/app/shared/constants/constants';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class TurnService {
  constructor(private http: HttpClient) { }

  private Url = environment.apiUrl + `/turn/`;

  mainPhase(): void {
    this.http.get(`${this.Url}main?gameId=${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
    `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

  attackPhase(): void {
    this.http.get(`${this.Url}attack?gameId=${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
    `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

  secondPhase(): void {
    this.http.get(`${this.Url}second?gameId=${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
    `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

  endTurn(): void {
    this.http.get(`${this.Url}end?gameId=${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
    `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

}
