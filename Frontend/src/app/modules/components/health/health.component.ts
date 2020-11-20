import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { IHealth } from '../../../shared/models/health';
import { HealthService } from '../../../core/services/health.service';

@Component({
  selector: 'app-health',
  templateUrl: './health.component.html',
})
export class HealthComponent implements OnInit {

  @Input() health: IHealth;

  constructor(private healthService: HealthService) { }

  ngOnInit(): void {
  }
}
