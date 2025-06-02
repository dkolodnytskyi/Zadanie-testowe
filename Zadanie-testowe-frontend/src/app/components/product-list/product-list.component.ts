import { ChangeDetectorRef, Component, OnInit, signal, WritableSignal } from '@angular/core';
import { ProductService } from '../../core/services/product.service';
import { Product } from '../../models/product.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CampaignService } from '../../core/services/campaign.service';
import { ToolsService } from '../../core/services/tools.service';
import { Keyword, Town } from '../../models/campaign.model';

@Component({
  standalone: true,
  selector: 'app-product-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss'
})
export class ProductListComponent implements OnInit {
  products: WritableSignal<Product[]> = signal([]);
  towns: Town[] = [];
  keywords: Keyword[] = [];
  isEditing: boolean = false;
  filteredKeywords: { id: string; name: string }[] = [];
  isLoading = true;
  error: string | null = null;
  selectedProductId: string | null = null;
  isFormVisible: boolean = false;
  validationsErrors: string = '';

  campaignForm = {
    name: '',
    keywordsIds: [] as string[],
    bidAmount: 0,
    campaignFund: 0,
    status: true,
    townId: '',
    radius: 0,
  };

  keywordInput = '';

  constructor(
    private productService: ProductService,
    private campaignService: CampaignService,
    private toolsService: ToolsService,
  ) { }

  ngOnInit(): void {
    this.loadProducts();

    this.toolsService.getKeywords().subscribe({
      next: (data) => this.keywords = data,
      error: (err) => console.error('Failed to load keywords:', err)
    });

    this.toolsService.getTowns().subscribe({
      next: (data) => this.towns = data,
      error: (err) => console.error('Failed to load towns:', err)
    });
  }

  filterKeywords(): void {
    const input = this.keywordInput.toLowerCase();
    this.filteredKeywords = this.keywords.filter(k =>
      k.name.toLowerCase().includes(input) &&
      !this.campaignForm.keywordsIds.includes(k.id)
    );
  }

  selectKeyword(keyword: { id: string; name: string }): void {
    this.campaignForm.keywordsIds.push(keyword.id);
    this.keywordInput = '';
    this.filteredKeywords = [];
  }

  removeKeyword(id: string): void {
    this.campaignForm.keywordsIds = this.campaignForm.keywordsIds.filter(kid => kid !== id);
  }

  getKeywordName(id: string): string {
    const match = this.keywords.find(k => k.id === id);
    return match ? match.name : id;
  }

  interactCampaign(id: string): void{
    console.log(id);
    this.campaignService.interactCampaign(id).subscribe({
      next: () => {
        this.loadProducts();
      },
      error: (err) => {
        this.validationsErrors = err.error.detail;
        console.log(err.error.detail);
      }
    });
  
    this.isFormVisible = false;
  }

  loadProducts(): void {
    this.productService.getAll().subscribe({
      next: (data) => {
        this.products.set(data);
        this.isLoading = false;
      },
      error: (err) => {
        this.error = 'Failed to load products.';
        this.isLoading = false;
      }
    });
  }

  showCampaignForm(productId: string, campaign?: any): void {
    this.selectedProductId = productId;
    this.isEditing = !!campaign;
    this.isFormVisible = true;

    console.log(this.selectedProductId);

    if (campaign) {
      this.campaignForm = {
        name: campaign.name || '',
        keywordsIds: campaign.keywords?.map((k: any) => k.id) || [],
        bidAmount: campaign.bidAmount || 0,
        campaignFund: campaign.campaignFund || 0,
        status: campaign.status ?? true,
        townId: campaign.town?.id || '',
        radius: campaign.radius || 0,
      };
    } else {
      // Reset form for new campaign
      this.campaignForm = {
        name: '',
        keywordsIds: [],
        bidAmount: 0,
        campaignFund: 0,
        status: true,
        townId: '',
        radius: 0,
      };
    }

    this.keywordInput = '';
  }

  updateKeywords(): void {
    this.campaignForm.keywordsIds = this.keywordInput
      .split(',')
      .map((id) => id.trim())
      .filter((id) => !!id);
  }

  submitCampaignForm(productId: string): void {
    if (this.isEditing) {
      this.campaignService.updateCampaign(productId, this.campaignForm).subscribe({
        next: () => {
          this.selectedProductId = null;
          this.isEditing = false;
          this.loadProducts();
          this.isFormVisible = false;
        },
        error: (err) => console.error(err)
      });
    } else {
      this.campaignService.createCampaign(productId, this.campaignForm).subscribe({
        next: () => {
          this.selectedProductId = null;
          this.loadProducts();
          this.isFormVisible = false;
        },
        error: (err) => console.error(err)
      });
    }
  }


  deleteCampaign(campaignId: string): void {
    this.campaignService.deleteCampaignFromProduct(campaignId).subscribe({
      next: () => {
        this.loadProducts(); // Refresh the list after deletion
      },
      error: (err) => {
        console.error('Failed to delete campaign:', err);
      }
    });
  }
}
