import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeSignComponent } from './welcome-sign.component';

describe('WelcomeSignComponent', () => {
  let component: WelcomeSignComponent;
  let fixture: ComponentFixture<WelcomeSignComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WelcomeSignComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeSignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
