import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PhoneBookEntry } from '../models/phoneBookEntry';
import { PhonebookService } from '../phonebook.service';

@Component({
  selector: 'app-phone-book-detail',
  templateUrl: './phone-book-detail.component.html',
  styleUrls: ['./phone-book-detail.component.css']
})
export class PhoneBookDetailComponent {

  constructor(
    public dialogRef: MatDialogRef<PhoneBookDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PhoneBookEntry,
    private readonly phonebookService: PhonebookService,

  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSave(): void {
    this.phonebookService.createEntry(this.data).subscribe(_ => this.dialogRef.close());
  }
}
