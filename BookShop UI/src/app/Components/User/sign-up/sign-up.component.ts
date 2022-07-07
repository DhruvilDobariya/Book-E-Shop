import { UserService } from './../../../Services/user.service';
import { User } from './../../../Models/user';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent implements OnInit {
    
    user = new User();
    confirmPassword : string = "";
    users : User[] = [];
    constructor(private _userService : UserService,private _route : Router) { }
    
    ngOnInit(): void {
        // this._bookService.getUsers(1).subscribe((responce : any) =>{
        //   this.users = responce.values;
        //   console.log(this.users);
        // });
    }
    
    submit(){
        this._userService.addUser(this.user).subscribe((responce : any) =>{
            this._route.navigate(['Signin']);
        });
    }
    
}
