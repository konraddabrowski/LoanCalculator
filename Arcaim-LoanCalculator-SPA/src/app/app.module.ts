import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatInputModule, MatSortModule, MatTableModule } from '@angular/material';

import { AppComponent } from './app.component';
import { InputComponent } from './angular_material_components/form_controls/input/input.component';
import { TableComponent } from './angular_material_components/data_table/table/table.component';
import { ButtonComponent } from './angular_material_components/buttons_and_indicators/button/button.component';
import { CdkTableModule } from '@angular/cdk/table';
import { PieChartComponent } from './angular_material_components/layout/pie-chart/pie-chart.component';
import { ErrorHandlerService } from './services/error-handler.service';
import { CreditService } from './services/credit.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    InputComponent,
    TableComponent,
    ButtonComponent,
    PieChartComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatInputModule,
    CdkTableModule,
    MatSortModule,
    MatTableModule,
    HttpClientModule,
  ],
  providers: [
    ErrorHandlerService,
    CreditService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
