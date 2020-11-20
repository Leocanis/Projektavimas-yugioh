import { TurnPhases } from './../../shared/enums/turnPhases';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { appConstants } from 'src/app/shared/constants/constants';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class TurnService {
  constructor(private http: HttpClient) { }

  private Url = environment.apiUrl + `/facade/`;

  attackPhase(): void {
    this.http.get(`${this.Url}turnPhase?phase=${TurnPhases.AttackPhase}&gameId=` +
      `${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
      `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

  secondPhase(): void {
    this.http.get(`${this.Url}turnPhase?phase=${TurnPhases.SecondPhase}&gameId=` +
      `${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
      `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

  endTurn(): void {
    this.http.get(`${this.Url}turnPhase?phase=${TurnPhases.EndTurn}&gameId=` +
      `${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
      `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

  forward(): void {
    this.http.get(`${this.Url}forward?gameId=${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
      `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }

  back(): void {
    this.http.get(`${this.Url}back?gameId=${sessionStorage.getItem(appConstants.sessionStorageGameId)}&playerId=` +
      `${sessionStorage.getItem(appConstants.sessionStoragePlayerId)}`).subscribe();
  }
}
