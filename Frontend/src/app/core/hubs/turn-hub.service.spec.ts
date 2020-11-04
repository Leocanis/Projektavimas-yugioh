import { TestBed } from '@angular/core/testing';

import { TurnHubService } from './turn-hub.service';

describe('TurnHubService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TurnHubService = TestBed.get(TurnHubService);
    expect(service).toBeTruthy();
  });
});
