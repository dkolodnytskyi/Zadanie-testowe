import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../../models/product.model";
import { environment } from "../../../environment";

@Injectable({ providedIn: 'root' })
export class ProductService {
    constructor(private http: HttpClient) {}
    private baseUrl = environment.apiBaseUrl+'/Helper';
    
    getAll(): Observable<Product[]> {
      return this.http.get<Product[]>(`${this.baseUrl}/products`);
    }
}
