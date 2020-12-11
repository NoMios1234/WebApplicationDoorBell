import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditWrlsscnComponent } from './add-edit-wrlsscn.component';

describe('AddEditWrlsscnComponent', () => {
  let component: AddEditWrlsscnComponent;
  let fixture: ComponentFixture<AddEditWrlsscnComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditWrlsscnComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditWrlsscnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
