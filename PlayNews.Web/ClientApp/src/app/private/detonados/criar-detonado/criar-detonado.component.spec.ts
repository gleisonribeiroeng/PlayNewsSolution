import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarDetonadoComponent } from './criar-detonado.component';

describe('CriarDetonadoComponent', () => {
  let component: CriarDetonadoComponent;
  let fixture: ComponentFixture<CriarDetonadoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CriarDetonadoComponent]
    });
    fixture = TestBed.createComponent(CriarDetonadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
