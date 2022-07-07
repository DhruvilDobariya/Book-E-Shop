import { UserService } from './../../../Services/user.service';
import { Component, OnInit } from '@angular/core';
import { Page } from 'src/app/Models/page';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-index',
    templateUrl: './user-index.component.html',
    styleUrls: ['./user-index.component.css']
})
export class UserIndexComponent implements OnInit {
    
    users : any[] = [];
    page : Page = new Page();
    
    constructor(private _userService : UserService, private _route : Router) { }
    
    ngOnInit(): void {
        this.getData(1,this.page.Count,this.page.keyword);
    }

    pageSize(e : any){
        this.page.Count = e.target.value;
        this.getData(1,this.page.Count,this.page.keyword);
    }

    search(e : any){
        this.page.keyword = e.target.value;
        this.getData(1,this.page.Count,this.page.keyword);
    }

    changePage(n : number){
        this.getData((this.page.CurruntPage + n),this.page.Count,this.page.keyword)
    }

    getData(page : number, count : number, keyword: string){
        this._userService.getUsers(page,count,keyword).subscribe((responce: any)=>{
            if(responce.values.length != 0){
                this.users = responce.values;
                this.page.CurruntPage = responce.curruntPage;
                this.page.Pages = responce.pages;
                if(this.page.CurruntPage < this.page.Pages){
                    this.page.right = false;
                }
                else{
                    this.page.right = true;
                }
                if(this.page.CurruntPage > 1){
                    this.page.left = false;
                }
                else{
                    this.page.left = true;
                }
            }
        });
    }

    Edit(id : number){
        this._route.navigate(["Category/Edit", id]);
    }

    Delete(id : number){
        this._userService.deleteUser(id).subscribe((responce: any)=>{
            this.getData(1,this.page.Count,this.page.keyword)
        });
    }
}
