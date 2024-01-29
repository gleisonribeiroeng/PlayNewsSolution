import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MancheteComponent } from './manchete.component';

describe('MancheteComponent', () => {
  let component: MancheteComponent;
  let fixture: ComponentFixture<MancheteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MancheteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MancheteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
