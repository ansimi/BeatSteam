import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SteamidComponent } from './steamid.component';

describe('SteamidComponent', () => {
  let component: SteamidComponent;
  let fixture: ComponentFixture<SteamidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SteamidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SteamidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
