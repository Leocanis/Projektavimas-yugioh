import { Component, OnDestroy } from '@angular/core';
import { SignalRService } from './services/signalr.service';
import { Subscription } from 'rxjs';
import { Message } from './message';
import { ClickService } from './services/click.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy {
  private signalRSubscription: Subscription;

  public content: Message;

  constructor(private signalrService: SignalRService,
              private clickService: ClickService) {
    this.signalRSubscription = this.signalrService.getMessage().subscribe(
      (message) => {
            this.content = message;

    });

  }
  ngOnDestroy(): void {
    this.signalrService.disconnect();
    this.signalRSubscription.unsubscribe();
  }

  onClicked(): void {
    this.clickService.sendClick();
  }
}
