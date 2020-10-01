import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IHealth } from 'src/app/shared/models/health';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HealthService {
  constructor(private http: HttpClient) { }

  private Url = `http://localhost:5000/api/health/getHealth`;

  getHealth(): Observable<IHealth> {
    const res = this.http.get<IHealth>(this.Url)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data)))
      );
    console.log('Kreipiuosi health');
    console.log(res);
    return res;
  }
}