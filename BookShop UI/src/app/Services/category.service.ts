import { Category } from './../Models/category';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  URL : string = "https://localhost:44382/api/Category";
  constructor(private _http : HttpClient) { }

  getCategories(page : number, count : number, keyword : string){
    return this._http.get(this.URL + "/list/?page=" + page + "&count=" + count + "&keyword=" + keyword);
  }

  getCategoryById(id : number){
    return this._http.get(this.URL + "/" + id);
  }

  addCategory(category : Category){
    return this._http.post(this.URL, category);
  }

  updateCategory(category : Category){
    return this._http.put(this.URL, category);
  }

  deleteCategory(id : number){
    return this._http.delete(this.URL + "/" + id);
  }
}
