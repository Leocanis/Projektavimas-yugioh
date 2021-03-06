import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IHealth } from '../../shared/models/health';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class HealthService {
  constructor(private http: HttpClient) { }

  private Url = environment.apiUrl + `/health/getHealth`;

  getHealth(playerId: number): Observable<IHealth> {
    const res = this.http.get<IHealth>(this.Url + '?playerId=' + playerId)
      .pipe(
        tap(data => { }));

    return res;
  }
}
