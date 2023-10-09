import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/IProduct';
import { IBombilla } from '../shared/models/IBombilla';
import { IYerbaMate } from '../shared/models/IYerbaMate';
import { ICup } from '../shared/models/ICup';
import { ShopService } from './shop.service';
import { IPagination } from '../shared/models/IPagination';
import { IProductType } from '../shared/models/IProductType';
import { IProductBrand } from '../shared/models/IProductBrand';
import { ICountry } from '../shared/models/ICountry';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  public products: IProduct[] = [];
  public types: IProductType[] = [];

  public isProductTypesCollapsed: boolean = false;

  public selectedProductTypeId: number = 0;
  public selectedProductTypeName: string | undefined;

  public selectedProductBrandId: number = 0;
  public selectedCountryId: number = 0;

  public sortSelected: string | undefined;
  sortOption = [
    { name: 'Alphabetical', value: 'Name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ]

  constructor(private shopService: ShopService) { }

  public ngOnInit(): void {
    this.getProductTypes();
    this.getProducts();
  }

  private getProductTypeName(selectedProductTypeId: number) {
    let productTypeName: string | undefined;
    productTypeName = this.types.find(x => x.id == selectedProductTypeId)?.name;
    return productTypeName ? productTypeName.toLowerCase().replace(/\s/g, '') : "";
  }

  public onSelectedProductType(selectedProductTypeId: number) {
    if (selectedProductTypeId == 0)
      this.reset()
    else {
      this.selectedProductTypeId = selectedProductTypeId;
      this.selectedProductTypeName = this.getProductTypeName(selectedProductTypeId);
      this.getProducts();
    }
  }

  public onSelectedCountry($event: number) {
    this.selectedCountryId = $event;
    this.getProducts();
  }

  public onSelectedBrand($event: number) {
    this.selectedProductBrandId = $event;
    this.getProducts();
  }

  public getProducts() {
    this.shopService.getProducts<IProduct>(
      this.selectedProductTypeName,
      this.selectedProductBrandId,
      this.selectedCountryId,
      this.sortSelected
    ).subscribe({
      next: result => this.products = result ? result.data : [],
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
    this.selectedProductTypeId = 0;
    this.selectedProductTypeName = undefined;
    this.selectedProductBrandId = 0;
    this.selectedCountryId = 0;
    this.sortSelected = undefined;
    this.getProducts();
  }

  public onSortSelected($event: Event) {
    this.sortSelected = ($event.target as HTMLSelectElement).value;
    this.getProducts();
  }
}
