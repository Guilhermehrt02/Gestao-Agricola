import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FarmMapView } from './farmMapView';

describe('FarmMapView', () => {
  let component: FarmMapView;
  let fixture: ComponentFixture<FarmMapView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FarmMapView],
    }).compileComponents();

    fixture = TestBed.createComponent(FarmMapView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
