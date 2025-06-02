import { Campaign } from "./campaign.model";

export interface Product {
    id: string;
    name: string;
    campaign: Campaign | null;
  }