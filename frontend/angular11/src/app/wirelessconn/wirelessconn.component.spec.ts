import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WirelessconnComponent } from './wirelessconn.component';

describe('WirelessconnComponent', () => {
  let component: WirelessconnComponent;
  let fixture: ComponentFixture<WirelessconnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WirelessconnComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WirelessconnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
