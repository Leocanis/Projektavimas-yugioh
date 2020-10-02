import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { IHealth } from '../../../shared/models/health';
import { Subscription } from 'rxjs';
import { HealthHubService } from 'src/app/core/hubs/health.hub.service';
import { HealthService } from 'src/app/core/services/health.service';

@Component({
  selector: 'app-health',
  templateUrl: './health.component.html',
})
export class HealthComponent implements OnInit, OnDestroy {
  private healthHubSubscription: Subscription;
  private health: IHealth;

  @Input() playerId: number;

  constructor(private healthHubService: HealthHubService,
    private healthService: HealthService) {
    this.healthHubSubscription = this.healthHubService.getHealth().subscribe(
      (health) => {
        if (this.playerId === health.playerId) {
          this.health = health.health;
        }
      });
  }

  ngOnInit(): void {
    this.healthService.getHealth(this.playerId).subscribe({
      next: health => {
        this.health = health;
      }
    });
  }

  ngOnDestroy(): void {
    this.healthHubService.disconnect();
    this.healthHubSubscription.unsubscribe();
  }
}
