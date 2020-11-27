import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ICard } from '../../shared/models/card';

@Injectable({
  providedIn: 'root'
})
export class CardhHubService {
  private card$: Subject<any>;
  private connection: signalR.HubConnection;

  constructor() {
    this.card$ = new Subject<any>();
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hubUrl + '/cardHub')
      .build();

    this.connect();
  }

  private connect() {
    this.connection.start().catch(err => console.log(err));

    this.connection.on('SendHealth', (health) => {
      this.card$.next(health);
    });
  }

  public getHealth(): Observable<any> {
    return this.card$;
  }

  public disconnect() {
    this.connection.stop();
  }
}
