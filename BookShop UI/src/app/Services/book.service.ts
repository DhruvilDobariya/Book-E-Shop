import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../Models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  URL : string = "https://localhost:44382/api/Book";
  constructor(private _http : HttpClient) { }

  getBooks(page : number, count : number, keyword : string){
    return this._http.get(this.URL + "/list/?page=" + page + "&count=" + count + "&keyword=" + keyword);
  }

  getBookById(id : number){
    return this._http.get(this.URL + "/" + id);
  }

  addBook(book : Book){
    return this._http.post(this.URL, book);
  }

  updateBook(book : Book){
    return this._http.put(this.URL, book);
  }

  deleteBook(id : number){
    return this._http.delete(this.URL + "/" + id);
  }
}
