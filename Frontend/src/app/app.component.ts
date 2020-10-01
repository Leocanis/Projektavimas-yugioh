import { ICard } from './shared/models/card';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Message } from './shared/models/message';
import { ClickService } from './core/services/click.service';
import { SignalRService } from './core/hubs/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy, OnInit {
  private signalRSubscription: Subscription;

  public content: Message = null;
  private card1: ICard;
  private card2: ICard;

  constructor(private signalrService: SignalRService,
              private clickService: ClickService) {
    this.signalRSubscription = this.signalrService.getMessage().subscribe(
      (message) => {
              this.content = message;
    });

  }
  ngOnInit(): void {
    this.card1 = { attack: 100} ;
    this.card2 = { attack: 150} ;
  }

  ngOnDestroy(): void {
    this.signalrService.disconnect();
    this.signalRSubscription.unsubscribe();
  }

  onClicked(): void {
    this.clickService.sendClick();
  }
}
