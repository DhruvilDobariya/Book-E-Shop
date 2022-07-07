import { UserIndexComponent } from './Components/User/user-index/user-index.component';
import { CartIndexComponent } from './Components/Cart/cart-index/cart-index.component';
import { BookAddEditComponent } from './Components/Book/book-add-edit/book-add-edit.component';
import { CategoryIndexComponent } from './Components/Category/category-index/category-index.component';
import { CategoryAddEditComponent } from './Components/Category/category-add-edit/category-add-edit.component';
import { BookIndexComponent } from './Components/Book/book-index/book-index.component';
import { SignInComponent } from './Components/User/sign-in/sign-in.component';
import { SignUpComponent } from './Components/User/sign-up/sign-up.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path : "",
        component : BookIndexComponent
    },
    {
        path : "Signup",
        component : SignUpComponent
    },
    {
        path : "Signin",
        component : SignInComponent
    },
    {
        path : "Users",
        component : UserIndexComponent
    },
    {
        path : "User/Edit/:id",
        component : SignUpComponent
    },
    {
        path : "Books",
        component : BookIndexComponent
    },
    {
        path : "Book/Add",
        component : BookAddEditComponent
    },
    {
        path : "Book/Edit/:id",
        component : BookAddEditComponent
    },
    {
        path : "Categories",
        component : CategoryIndexComponent
    },
    {
        path : "Category/Add",
        component : CategoryAddEditComponent
    },
    {
        path : "Category/Edit/:id",
        component : CategoryAddEditComponent
    },
    {
        path : "Cart",
        component : CartIndexComponent
    },
    
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
