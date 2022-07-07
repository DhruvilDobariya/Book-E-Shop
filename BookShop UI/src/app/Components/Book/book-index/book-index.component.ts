import { BookService } from './../../../Services/book.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Page } from 'src/app/Models/page';

@Component({
    selector: 'app-book-index',
    templateUrl: './book-index.component.html',
    styleUrls: ['./book-index.component.css']
})
export class BookIndexComponent implements OnInit {
    
    books : any[] = [];
    page : Page = new Page();
    
    constructor(private _bookService : BookService, private _route : Router) { }
    
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
        this._bookService.getBooks(page,count,keyword).subscribe((responce: any)=>{
            if(responce.values.length != 0){
                this.books = responce.values;
                this.page.CurruntPage = responce.curruntPage;
                console.log(this.books);
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

    Detail(id : number){
        this._route.navigate(["Category/Detail", id]);
    }
    
}
