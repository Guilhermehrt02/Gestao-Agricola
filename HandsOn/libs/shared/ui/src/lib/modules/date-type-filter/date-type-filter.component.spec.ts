import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DateTypeFilterComponent } from './date-type-filter.component';

describe('DateTypeFilterComponent', () => {
  let component: DateTypeFilterComponent;
  let fixture: ComponentFixture<DateTypeFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DateTypeFilterComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(DateTypeFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
