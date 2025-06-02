import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Campaign } from '../../models/campaign.model';
import { environment } from "../../../environment";

export interface CampaignDto {
  name: string;
  keywordsIds: string[];
  bidAmount: number;
  campaignFund: number;
  status: boolean;
  townId: string;
  radius: number;
}


@Injectable({ providedIn: 'root' })
export class CampaignService {
  constructor(private http: HttpClient) { }
  private baseUrl = environment.apiBaseUrl+'/Campaign';


  createCampaign(productId: string, campaign: CampaignDto): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/add-to-product?productId=${productId}`, campaign);
  }

  deleteCampaignFromProduct(campaignId: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/delete/${campaignId}`);
  }

  updateCampaign(productId: string, campaign: CampaignDto): Observable<any> {
    return this.http.put<any>(
      `${this.baseUrl}/edit?productId=${productId}`,
      campaign
    );
  }

  interactCampaign(campaignId: string): Observable<any> {
    return this.http.post<any>(
      `${this.baseUrl}/interact?campaignId=${campaignId}`,null
    );
  }
}

