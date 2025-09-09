import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ImageCompare } from './imageCompare';

describe('ImageCompare', () => {
  let component: ImageCompare;
  let fixture: ComponentFixture<ImageCompare>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ImageCompare],
    }).compileComponents();

    fixture = TestBed.createComponent(ImageCompare);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
