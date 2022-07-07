import { Cart } from './../Models/cart';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  URL : string = "https://localhost:44382/api/Cart";
  constructor(private _http : HttpClient) { }

  getCarts(page : number, count : number, keyword : string){
    return this._http.get(this.URL + "/list/?page=" + page + "&count=" + count + "&keyword=" + keyword);
  }

  getCartById(id : number){
    return this._http.get(this.URL + "/" + id);
  }

  addCart(cart : Cart){
    return this._http.post(this.URL, cart);
  }

  updateCart(cart : Cart){
    return this._http.put(this.URL, cart);
  }

  deleteCart(id : number){
    return this._http.delete(this.URL + "/" + id);
  }
}
