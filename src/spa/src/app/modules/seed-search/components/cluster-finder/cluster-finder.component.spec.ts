import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClusterFinderComponent } from './cluster-finder.component';

describe('ClusterFinderComponent', () => {
  let component: ClusterFinderComponent;
  let fixture: ComponentFixture<ClusterFinderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClusterFinderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClusterFinderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
