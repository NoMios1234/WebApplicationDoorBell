import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPlstComponent } from './add-edit-plst.component';

describe('AddEditPlstComponent', () => {
  let component: AddEditPlstComponent;
  let fixture: ComponentFixture<AddEditPlstComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPlstComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPlstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
