import {Component, OnInit, Input, ChangeDetectionStrategy, ChangeDetectorRef} from '@angular/core';
import {MatSort, MatTableDataSource} from '@angular/material';
import { Observable } from 'rxjs';
import { FinancialResultModel } from 'src/app/domains/financial-result-model';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TableComponent implements OnInit {

  constructor() { }

  @Input() ArraySource: any[];
  dataSource: MatTableDataSource<any[]>;

  displayedColumns: string[] = [
    'monthNumber',
    // 'Installment',
    'capitalPartOfInstallment',
    'interestPartOfInstallment',
    'capitalToRepay',
    'interestToRepay'
  ];

  ngOnInit() {
      this.dataSource = new MatTableDataSource(this.ArraySource);
  }

}
