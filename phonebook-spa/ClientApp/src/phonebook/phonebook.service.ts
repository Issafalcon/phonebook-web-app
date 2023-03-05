import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, EMPTY, Observable, switchMap } from 'rxjs';
import { PhoneBookEntry } from './models/phoneBookEntry';

@Injectable({
  providedIn: 'root'
})
export class PhonebookService {

  constructor(
    private readonly http: HttpClient,
    @Inject('BASE_URL') private readonly baseUrl: string,
  ) { }

  getEntries(): Observable<PhoneBookEntry[]> {
    return this.http.get<PhoneBookEntry[]>(this.baseUrl + 'phonebook').pipe(
      catchError(er => { console.error(er); return EMPTY })
    );
  }

  createEntry(entry: PhoneBookEntry): Observable<PhoneBookEntry> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    return this.http.post<PhoneBookEntry>(this.baseUrl + 'phonebook', entry, httpOptions).pipe(
      catchError(er => { console.error(er); return EMPTY })
    )
  }
}
