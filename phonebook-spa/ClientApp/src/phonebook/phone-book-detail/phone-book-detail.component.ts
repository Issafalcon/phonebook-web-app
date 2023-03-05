import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PhoneBookDialogData } from '../models/phoneBookDialogData';
import { PhonebookService } from '../phonebook.service';

@Component({
  selector: 'app-phone-book-detail',
  templateUrl: './phone-book-detail.component.html',
  styleUrls: ['./phone-book-detail.component.css']
})
export class PhoneBookDetailComponent {

  constructor(
    public dialogRef: MatDialogRef<PhoneBookDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PhoneBookDialogData,
    private readonly phonebookService: PhonebookService,

  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSave(): void {
    if (this.data.isEdit) {
      this.phonebookService.updateEntryById(this.data.entry).subscribe(_ => this.dialogRef.close());
    } else {
      this.phonebookService.createEntry(this.data.entry).subscribe(_ => this.dialogRef.close());
    }
  }
}
