import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetonadosComponent } from './detonados.component';

describe('DetonadosComponent', () => {
  let component: DetonadosComponent;
  let fixture: ComponentFixture<DetonadosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DetonadosComponent]
    });
    fixture = TestBed.createComponent(DetonadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
