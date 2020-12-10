import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSampComponent } from './show-samp.component';

describe('ShowSampComponent', () => {
  let component: ShowSampComponent;
  let fixture: ComponentFixture<ShowSampComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSampComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowSampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
