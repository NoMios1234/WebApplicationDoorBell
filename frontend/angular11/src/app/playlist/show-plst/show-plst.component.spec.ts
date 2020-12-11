import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPlstComponent } from './show-plst.component';

describe('ShowPlstComponent', () => {
  let component: ShowPlstComponent;
  let fixture: ComponentFixture<ShowPlstComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPlstComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPlstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
