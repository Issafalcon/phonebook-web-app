import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { PhoneBookEntry } from '../models/phoneBookEntry';

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css'],
})
export class PhoneBookComponent implements OnInit {
  public entries: PhoneBookEntry[] = [];

  constructor(
    private readonly http: HttpClient,
    @Inject('BASE_URL') private readonly baseUrl: string
  ) {}

  ngOnInit(): void {
    this.http.get<PhoneBookEntry[]>(this.baseUrl + 'phonebook').subscribe(
      (result) => {
        this.entries = result;
      },
      (error) => console.error(error)
    );
  }
}
