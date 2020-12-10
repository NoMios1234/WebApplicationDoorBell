import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditLibComponent } from './add-edit-lib.component';

describe('AddEditLibComponent', () => {
  let component: AddEditLibComponent;
  let fixture: ComponentFixture<AddEditLibComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditLibComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditLibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
