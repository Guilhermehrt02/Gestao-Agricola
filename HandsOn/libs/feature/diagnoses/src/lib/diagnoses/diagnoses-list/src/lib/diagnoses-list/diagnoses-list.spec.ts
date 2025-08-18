import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DiagnosesList } from './diagnoses-list';

describe('DiagnosesList', () => {
  let component: DiagnosesList;
  let fixture: ComponentFixture<DiagnosesList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DiagnosesList],
    }).compileComponents();

    fixture = TestBed.createComponent(DiagnosesList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
