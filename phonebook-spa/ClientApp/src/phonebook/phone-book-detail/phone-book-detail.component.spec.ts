import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneBookDetailComponent } from './phone-book-detail.component';

describe('PhoneBookDetailComponent', () => {
  let component: PhoneBookDetailComponent;
  let fixture: ComponentFixture<PhoneBookDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhoneBookDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhoneBookDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
