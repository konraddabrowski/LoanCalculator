import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { TrackerErrorModel } from '../domains/tracker-error-model';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

constructor() { }

  handle(error: HttpErrorResponse, friendlyMessage: string): Observable<TrackerErrorModel> {
    const dataError = new TrackerErrorModel();
    dataError.errorNumber = 100;
    dataError.message = error.statusText;
    dataError.friendlyMessage = friendlyMessage;
    return throwError(dataError);
  }

}
