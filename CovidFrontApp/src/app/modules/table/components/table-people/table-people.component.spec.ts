import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePeopleComponent } from './table-people.component';

describe('TablePeopleComponent', () => {
  let component: TablePeopleComponent;
  let fixture: ComponentFixture<TablePeopleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablePeopleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablePeopleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
