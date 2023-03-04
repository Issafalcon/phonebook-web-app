import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PhoneBookComponent } from './phone-book/phone-book.component';
import { PhoneBookRoutingModule } from './phonebook-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [PhoneBookComponent],
  imports: [
    CommonModule,
    PhoneBookRoutingModule,
    MatToolbarModule,
    MatIconModule,
  ],
})
export class PhonebookModule {}
