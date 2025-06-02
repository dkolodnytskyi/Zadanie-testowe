export interface Campaign {
    id: string;
    name: string;
    keywords: Keyword[];
    bidAmount: number;
    campaignFund: number;
    status: boolean;
    town: Town;
    radius: number;
  }

export interface Keyword {
    id: string;
    name: string;
  }

export interface Town {
    id: string;
    name: string;
  }