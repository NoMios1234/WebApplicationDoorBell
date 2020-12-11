import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowWrlsscnComponent } from './show-wrlsscn.component';

describe('ShowWrlsscnComponent', () => {
  let component: ShowWrlsscnComponent;
  let fixture: ComponentFixture<ShowWrlsscnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowWrlsscnComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowWrlsscnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
