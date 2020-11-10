import { Component } from '@angular/core';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent {

    private _loginName: string;

    get loginName(): string {
        return this._loginName;
    }
    set loginName(value: string) {
        this._loginName = value;
    }

    onLogin(): void {
        if (this._loginName) {
            console.log(this._loginName);
        }
    }
}
