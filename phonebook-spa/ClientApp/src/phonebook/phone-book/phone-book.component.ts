import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PhoneBookEntry } from '../models/phoneBookEntry';
import { MatDialog } from '@angular/material/dialog';
import { PhoneBookDetailComponent } from '../phone-book-detail/phone-book-detail.component';
import { PhonebookService } from '../phonebook.service';
import { debounceTime, distinctUntilChanged, fromEvent, map } from 'rxjs';

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css'],
})
export class PhoneBookComponent implements OnInit, AfterViewInit {
  public entries: PhoneBookEntry[] = [];
  public filteredEntries: PhoneBookEntry[] = [];
  public search: string;
  @ViewChild('searchInput') searchInput: ElementRef;

  constructor(
    private readonly phonebookService: PhonebookService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.refreshEntries();
  }

  ngAfterViewInit(): void {
    fromEvent(this.searchInput.nativeElement, 'input')
      .pipe(map((event: Event) => (event.target as HTMLInputElement).value),
        debounceTime(500),
        distinctUntilChanged())
      .subscribe(data => this.updateFilteredEntities());
  }

  onAddContact(): void {
    const newEntry: PhoneBookEntry = {
      firstName: undefined,
      lastName: undefined,
      phoneNumber: undefined
    }

    const dialogRef = this.dialog.open(PhoneBookDetailComponent, {
      data: { entry: newEntry }
    })

    dialogRef.afterClosed().subscribe(_ => {
      this.refreshEntries();
    })
  }

  onDeleteContact(id: number) {
    this.phonebookService.deleteEntryById(id).subscribe(_ => {
      this.refreshEntries();
    });
  }

  onEditContact(entry: PhoneBookEntry) {
    const dialogRef = this.dialog.open(PhoneBookDetailComponent, {
      data: { entry: entry, isEdit: true }
    })

    dialogRef.afterClosed().subscribe(_ => {
      this.refreshEntries();
    })
  }

  trackByItems(_: number, item: PhoneBookEntry): number { return item.id; }

  private refreshEntries(): void {
    this.phonebookService.getEntries().subscribe(
      (result) => {
        this.entries = result;
        this.updateFilteredEntities();
      }
    );
  }

  private updateFilteredEntities(): void {
    this.filteredEntries = this.entries.filter(entry => {
      if (this.search) {
        return entry.lastName.toLowerCase().includes(this.search.toLowerCase())
      }

      return true;
    })
  }
}
