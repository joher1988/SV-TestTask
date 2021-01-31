/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SVEntitiesService } from './SVEntities.service';

describe('Service: SVEntities', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SVEntitiesService]
    });
  });

  it('should ...', inject([SVEntitiesService], (service: SVEntitiesService) => {
    expect(service).toBeTruthy();
  }));
});
