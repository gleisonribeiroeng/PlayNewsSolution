import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PequenoBlogComponent } from './pequeno-blog.component';

describe('PequenoBlogComponent', () => {
  let component: PequenoBlogComponent;
  let fixture: ComponentFixture<PequenoBlogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PequenoBlogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PequenoBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
