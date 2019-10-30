import { Injectable } from '@angular/core';
import { CreditModel } from '../Domains/credit-model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ErrorHandlerService } from './error-handler.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { FinancialResultModel } from '../domains/financial-result-model';

@Injectable({
  providedIn: 'root'
})
export class CreditService {

  constructor(private http: HttpClient, private httpErrorHandler: ErrorHandlerService) { }

  public getEqualInstallmentResult(credit: CreditModel): Observable<Array<FinancialResultModel>> {
    const params = new HttpParams().set('amount', credit.AmountOfCredit.toString())
                                   .set('annual', credit.AnnualLendingRate.toString())
                                   .set('months', credit.LifeOfLoan.toString());
    return this.http.get<any>(`http://localhost:5000/api/credits/GetEqualInstallmentResult`, { params }).pipe(
      catchError(error => this.httpErrorHandler.handle(error, 'An error occurred retrieving years for user.'))
    );
  }
}
