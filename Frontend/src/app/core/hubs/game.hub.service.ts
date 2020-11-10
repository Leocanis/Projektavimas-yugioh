import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IHealth } from '../../shared/models/health';

@Injectable({
  providedIn: 'root'
})
export class HealthHubService {
  private game$: Subject<any>;
  private connection: signalR.HubConnection;

  constructor() {
    this.game$ = new Subject<any>();
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hubUrl + '/gameHub')
      .build();

    this.connect();
  }

  private connect() {
    this.connection.start().catch(err => console.log(err));

    this.connection.on('SendGame', (game) => {
      this.game$.next(game);
    });
  }

  public getHealth(): Observable<any> {
    return this.game$;
  }

  public disconnect() {
    this.connection.stop();
  }
}
