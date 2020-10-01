import { Component, OnInit } from '@angular/core';
import { IHealth } from '../../../shared/models/health';
import { Subscription } from 'rxjs';
import { HealthHubService } from 'src/app/core/hubs/health.hub.service';
import { HealthService } from 'src/app/core/services/health.service';

@Component({
  selector: 'app-health',
  templateUrl: './health.component.html',
})
export class HealthComponent implements OnInit {
  private healthHubSubscription: Subscription;
  private health: IHealth;

  constructor(private healthHubService: HealthHubService,
    private healthService: HealthService) {
    this.healthHubSubscription = this.healthHubService.getHealth().subscribe(
      (health) => {
        this.health = health.health;
      });
  }

  ngOnInit(): void {
    this.healthService.getHealth().subscribe({
      next: health =>
      {
        this.health = health;
      }
    });
  }
}
