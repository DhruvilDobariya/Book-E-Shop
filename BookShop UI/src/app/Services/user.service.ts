import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  URL : string = "https://localhost:44382/api/User";
  constructor(private _http : HttpClient) { }

  getUsers(page : number, count : number, keyword : string){
    return this._http.get(this.URL + "/list/?page=" + page + "&count=" + count + "&keyword=" + keyword);
  }

  getUserById(id : number){
    return this._http.get(this.URL + "/" + id);
  }

  addUser(user : User){
    return this._http.post(this.URL, user);
  }

  updateUser(user : User){
    return this._http.put(this.URL, user);
  }

  deleteUser(id : number){
    return this._http.delete(this.URL + "/" + id);
  }
}
