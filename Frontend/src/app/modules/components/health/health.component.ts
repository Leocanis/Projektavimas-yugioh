import { IHealth } from '../../../shared/models/health';
import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { HealthHubService } from 'src/app/core/hubs/health.hub.service';

@Component({
    selector: 'app-health',
    templateUrl: './health.component.html',
  })
  export class HealthComponent {
    private healthHubSubscription: Subscription;
    private health: IHealth;

    constructor(private healthHubService: HealthHubService) {
    this.healthHubSubscription = this.healthHubService.getHealth().subscribe(
    (health) => {
          this.health = health.health;
    });
  }
}
