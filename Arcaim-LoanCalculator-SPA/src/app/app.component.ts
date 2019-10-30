import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ShortFinancialResultModel } from './Domains/short-financial-result-model';
import { FinancialResultModel } from './domains/financial-result-model';
import { CreditModel } from './Domains/credit-model';
import { CreditService } from './services/credit.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  shortFinancialResult: ShortFinancialResultModel[];

  public financialResult: FinancialResultModel[];

  public credit: CreditModel;

  constructor(private creditService: CreditService
    // , private changeDetectorRefs: ChangeDetectorRef
    ) { }

  ngOnInit() {
    this.credit = new CreditModel();
  }

  setAmountOfCredit(value: string) {
    this.credit.AmountOfCredit = +value;
  }

  setAnnualLendingRate(value: string) {
    this.credit.AnnualLendingRate = +value;
  }

  setLifeOfLoan(value: string) {
    this.credit.LifeOfLoan = +value;
  }

  getEqualInstallmentResult() {
    if (this.credit.AmountOfCredit && this.credit.AnnualLendingRate && this.credit.LifeOfLoan) {
      this.creditService.getEqualInstallmentResult(this.credit).pipe(
        map((requests: FinancialResultModel[]) =>
          requests.map(request =>
            new FinancialResultModel(request.monthNumber,
                                     request.capitalPartOfInstallment,
                                     request.interestPartOfInstallment,
                                     request.capitalToRepay,
                                     request.interestToRepay)
        ))).subscribe(
        (result: FinancialResultModel[]) => {
          this.financialResult = result;
          // this.changeDetectorRefs.detectChanges();
          // let interest = 0;
          // result.forEach(element => {
          //   interest += +element.interestPartOfInstallment;
          // });
          // ,
          // this.shortFinancialResult = [new ShortFinancialResultModel(
          //   this.credit.AmountOfCredit,
          //   interest,
          //   this.credit.AmountOfCredit + interest
          // )];
        }
      );
    }
  }
}
