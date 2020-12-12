import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCamComponent } from './show-cam.component';

describe('ShowCamComponent', () => {
  let component: ShowCamComponent;
  let fixture: ComponentFixture<ShowCamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
