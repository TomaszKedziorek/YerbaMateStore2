import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/IProduct';
import { ShopService } from './shop.service';
import { IProductType } from '../shared/models/IProductType';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  public products: IProduct[] = [];
  public types: IProductType[] = [];

  public isProductTypesCollapsed: boolean = false;

  public shopParams: ShopParams = new ShopParams();
  public totalCount!: number;
  public typeName: string | undefined;

  public sortOption = [
    { name: 'Alphabetical', value: 'Name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  public pageSizeOption = [
    { name: '4', value: 4 },
    { name: '8', value: 8 },
    { name: '12', value: 12 },
    { name: '24', value: 24 },
  ];

  constructor(private shopService: ShopService) { }

  public ngOnInit(): void {
    this.getProductTypes();
    this.getProducts();
  }

  private getProductTypeName(typeId: number) {
    let productTypeName: string | undefined;
    productTypeName = this.types.find(x => x.id == typeId)?.name;
    return productTypeName ? productTypeName.toLowerCase().replace(/\s/g, '') : "";
  }

  public onSelectedProductType(typeId: number) {
    if (typeId == 0)
      this.reset()
    else {
      this.shopParams.typeId = typeId;
      this.typeName = this.getProductTypeName(typeId);
      this.getProducts();
    }
  }

  public onSelectedCountry($event: number) {
    this.shopParams.countryId = $event;
    this.getProducts();
  }

  public onSelectedBrand($event: number) {
    this.shopParams.brandId = $event;
    this.getProducts();
  }

  public getProducts() {
    this.shopService.getProducts<IProduct>(this.shopParams, this.typeName).subscribe({
      next: result => {
        if (result) {
          this.products = result.data;
          this.shopParams.pageNumber = result.pageIndex;
          this.shopParams.pageSize = result.pageSize;
          this.totalCount = result.count;
        }
      }
      ,
      error: err => console.log(err)
    });
  }

  public getProductTypes() {
    this.shopService.getProductTypes().subscribe({
      next: result => this.types = [{ id: 0, name: 'All' }, ...result],
      error: err => console.log(err)
    });
  }

  public reset(): void {
    this.typeName = undefined;
    this.shopParams = new ShopParams();
    this.getProducts();
  }

  public onSortSelected($event: Event) {
    this.shopParams.sort = ($event.target as HTMLSelectElement).value;
    this.getProducts();
  }

  public onPageChanged(event: any): void {
    this.shopParams.pageNumber = event;   
    this.getProducts();
  }

  public onPageSizeSelect($event: Event) {
    this.shopParams.pageSize = <number> <unknown>($event.target as HTMLSelectElement).value;    
    this.getProducts();
  }
}
