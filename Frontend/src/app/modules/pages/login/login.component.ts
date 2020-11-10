import { IMessage } from 'src/app/shared/models/message';
import { Component } from '@angular/core';
import { LoginService } from 'src/app/core/services/login.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent {

    constructor(private loginService: LoginService) { }

    private loginName: string;
    private message: IMessage;

    onLogin(): void {
        if (this.loginName) {
            this.loginService.Login(this.loginName).subscribe(success => {
                this.message = success;
            });
        }
        console.log(this.message);
    }

    checkMessage(): void {
        console.log(this.message);
    }
}
