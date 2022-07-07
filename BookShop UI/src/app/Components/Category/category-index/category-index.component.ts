import { Router } from '@angular/router';
import { Page } from './../../../Models/page';
import { CategoryService } from './../../../Services/category.service';
import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/Models/category';

@Component({
    selector: 'app-category-index',
    templateUrl: './category-index.component.html',
    styleUrls: ['./category-index.component.css']
})
export class CategoryIndexComponent implements OnInit {
    
    categories : any[] = [];
    page : Page = new Page();
    
    constructor(private _categoryService : CategoryService, private _route : Router) { }
    
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
        this._categoryService.getCategories(page,count,keyword).subscribe((responce: any)=>{
            if(responce.values.length != 0){
                //console.log(responce)
                this.categories = responce.values;
                //console.log(this.categories);
                this.page.CurruntPage = responce.curruntPage;
                //console.log(this.page.CurruntPage);
                this.page.Pages = responce.pages;
                //console.log(this.page.Pages);
                if(this.page.CurruntPage < this.page.Pages){
                    this.page.right = false;
                    //console.log(this.page.right);
                }
                else{
                    this.page.right = true;
                }
                if(this.page.CurruntPage > 1){
                    this.page.left = false;
                    //console.log(this.page.left);
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
        this._categoryService.deleteCategory(id).subscribe((responce: any)=>{
            this.getData(1,this.page.Count,this.page.keyword)
        });
    }
    
}
