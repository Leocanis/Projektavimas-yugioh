
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IGame } from 'src/app/shared/models/game';
import { appConstants } from 'src/app/shared/constants/constants';

@Injectable({
  providedIn: 'root'
})
export class GameHubService {
  private game$: Subject<IGame>;
  private connection: signalR.HubConnection;

  constructor() {
    this.game$ = new Subject<IGame>();
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hubUrl + '/gameHub')
      .build();

    this.connect();
  }

  private connect() {
    this.connection.start()
      .catch(err => console.log(err));

    this.connection.on(sessionStorage.getItem(appConstants.sessionStorageGameId), (game) => {
      this.game$.next(game);
    });
  }

  public getGame(): Observable<IGame> {
    return this.game$;
  }

  public disconnect() {
    this.connection.stop();
  }
}
