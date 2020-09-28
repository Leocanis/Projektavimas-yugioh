import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })

  export class ClickService {
    constructor(private http: HttpClient) { }

    private Url = `http://localhost:5000/api/click`;

    sendClick() {
          this.http.get(this.Url).subscribe();
    }
}