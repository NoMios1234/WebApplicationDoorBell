import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AudiolibComponent } from './audiolib.component';

describe('AudiolibComponent', () => {
  let component: AudiolibComponent;
  let fixture: ComponentFixture<AudiolibComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AudiolibComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AudiolibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
