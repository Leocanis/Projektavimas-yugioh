import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Subject, Observable } from 'rxjs';
import { Message } from 'src/app/shared/models/message';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private message$: Subject<Message>;
  private connection: signalR.HubConnection;

  constructor() {
    this.message$ = new Subject<Message>();
    this.connection = new signalR.HubConnectionBuilder()
    .withUrl(environment.hubUrl + 'notificationHub')
    .build();

    this.connect();
  }

  private connect() {
    this.connection.start().catch(err => console.log(err));

    this.connection.on('SendMessage', (message) => {
      this.message$.next(message);
    });
  }

  public getMessage(): Observable<Message> {
    return this.message$;
  }

  public disconnect() {
    this.connection.stop();
  }
}
