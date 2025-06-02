import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environment";
import { Keyword, Town } from "../../models/campaign.model";

@Injectable({ providedIn: 'root' })
export class ToolsService {
    constructor(private http: HttpClient) {}
    private baseUrl = environment.apiBaseUrl+'/Helper';
    
    getTowns(): Observable<Town[]> {
      return this.http.get<Town[]>(`${this.baseUrl}/towns`);
    }

    getKeywords(): Observable<Keyword[]> {
      return this.http.get<Keyword[]>(`${this.baseUrl}/keywords`);
    }
}