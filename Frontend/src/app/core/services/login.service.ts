import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IMessage } from 'src/app/shared/models/message';

@Injectable({
    providedIn: 'root'
})

export class LoginService {
    constructor(private http: HttpClient) { }

    private Url = environment.apiUrl + `/login`;

    Login(loginName: string): Observable<IMessage> {

        return this.http.get<IMessage>(this.Url + '?loginName=' + loginName)
            .pipe(
                tap(data => { }));
    }
}
