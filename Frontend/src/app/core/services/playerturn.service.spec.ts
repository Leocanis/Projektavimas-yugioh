import { TestBed } from '@angular/core/testing';

import { PlayerturnService } from './playerturn.service';

describe('PlayerturnService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PlayerturnService = TestBed.get(PlayerturnService);
    expect(service).toBeTruthy();
  });
});
