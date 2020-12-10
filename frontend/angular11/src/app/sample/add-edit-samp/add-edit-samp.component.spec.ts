import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSampComponent } from './add-edit-samp.component';

describe('AddEditSampComponent', () => {
  let component: AddEditSampComponent;
  let fixture: ComponentFixture<AddEditSampComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSampComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditSampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
