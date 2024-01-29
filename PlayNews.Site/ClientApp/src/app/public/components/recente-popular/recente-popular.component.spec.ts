import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentePopularComponent } from './recente-popular.component';

describe('RecentePopularComponent', () => {
  let component: RecentePopularComponent;
  let fixture: ComponentFixture<RecentePopularComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecentePopularComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecentePopularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
