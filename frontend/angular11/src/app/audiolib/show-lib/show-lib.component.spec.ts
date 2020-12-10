import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowLibComponent } from './show-lib.component';

describe('ShowLibComponent', () => {
  let component: ShowLibComponent;
  let fixture: ComponentFixture<ShowLibComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowLibComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowLibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
