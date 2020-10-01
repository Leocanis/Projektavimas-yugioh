import { Component, OnInit } from '@angular/core';
import { Subscription, Subject } from 'rxjs';
import { SignalRService } from '../core/hubs/signalr.service';
import { Message } from '../shared/models/message';

@Component({
  selector: 'app-other',
  templateUrl: './other.component.html'
})
export class OtherComponent  {
  private signalRSubscription: Subscription;
  totalString: string;
  constructor(private signalrService: SignalRService) {
    this.signalRSubscription = this.signalrService.getMessage()
    .subscribe(
      (message: Message) => {
          this.totalString = `${message.val1} ${message.val2} ${message.val3} ${message.val4}`;
    });
  }
  disconnect() {
   // this.signalRSubscription.unsubscribe();

   const p = this.signalrService.getMessage() as Subject<any>;
   p.next( {val1: 'a'});

  }
}
