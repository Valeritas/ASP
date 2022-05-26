import { Injectable }   from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Potion } from "../model/potion.model";
import { Observable } from "rxjs";
@Injectable({
    providedIn: 'root'
})
export class PotionsService{
    url = "https://localhost:7185/api/potions";
 
    constructor(private http: HttpClient) {
    }
 
    getAllPotions():Observable<Potion[]> {
        return this.http.get<Potion[]>(this.url);
    }
     
}
