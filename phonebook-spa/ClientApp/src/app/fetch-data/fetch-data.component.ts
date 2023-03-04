import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PhoneBookEntry } from './models/phoneBookEntry';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public entries: PhoneBookEntry[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PhoneBookEntry[]>(baseUrl + 'phonebook').subscribe(
      (result) => {
        this.entries = result;
      },
      (error) => console.error(error)
    );
  }
}
