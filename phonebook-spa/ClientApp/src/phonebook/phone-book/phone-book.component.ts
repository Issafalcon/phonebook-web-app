import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { PhoneBookEntry } from '../models/phoneBookEntry';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PhoneBookDetailComponent } from '../phone-book-detail/phone-book-detail.component';
import { PhonebookService } from '../phonebook.service';

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css'],
})
export class PhoneBookComponent implements OnInit {
  public entries: PhoneBookEntry[] = [];

  constructor(
    private readonly phonebookService: PhonebookService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.phonebookService.getEntries().subscribe(
      (result) => {
        this.entries = result;
      }
    );
  }

  onAddContact(): void {
    const dialogRef = this.dialog.open(PhoneBookDetailComponent, {
      data: { firstName: '', lastName: '', phoneNumber: '' }
    })
  }

  onDeleteContact(id: number) {
    console.log(id)
  }
}
