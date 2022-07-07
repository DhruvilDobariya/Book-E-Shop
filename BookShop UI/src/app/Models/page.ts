export class Page {
    CurruntPage : number;
    Pages : number;
    Count : number;
    keyword : string;
    left : boolean; 
    right : boolean;

    constructor(){
        this.Pages = 0;
        this.CurruntPage = 0;
        this.Count = 5 ;
        this.keyword = "";
        this.left = true; 
        this.right = true;
    }
}
