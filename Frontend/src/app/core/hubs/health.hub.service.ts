import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IHealth } from '../../shared/models/health';

@Injectable({
    providedIn: 'root'
  })
  export class HealthHubService {
    private health$: Subject<any>;
    private connection: signalR.HubConnection;

    constructor() {
      this.health$ = new Subject<any>();
      this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hubUrl + 'healthHub')
      .build();

      this.connect();
    }

    private connect() {
      this.connection.start().catch(err => console.log(err));

      this.connection.on('SendHealth', (health) => {
        this.health$.next(health);
      });
    }

    public getHealth(): Observable<any> {
      return this.health$;
    }

    public disconnect() {
      this.connection.stop();
    }
  }