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
  public brands: IProductBrand[] = [];
  public countries: ICountry[] = [];

  public isCountriesCollapsed: boolean = true;
  public isProductTypesCollapsed: boolean = false;
  public isProductBrandsCollapsed: boolean = true;
  public activeProductTypeId: number = 0;
  public activeProductBrandId: number = 0;
  public activeCountryId: number = 0;


  constructor(private shopService: ShopService) { }

  public ngOnInit(): void {
    this.getProducts();
    this.getProductTypes();
    this.getProductBrands();
    this.getProductCountries();
  }

  private setActiveProductType(selectedProductTypeId: number) {
    this.activeProductTypeId = selectedProductTypeId;
  }
  private getProductTypeName(selectedProductTypeId: number) {
    let productTypeName: string | undefined;
    productTypeName = this.types.find(x => x.id == selectedProductTypeId)?.name;
    return productTypeName ? productTypeName.toLowerCase().replace(/\s/g, '') : "";
  }

  public setActiveCountry(selectedCountryId: number) {
    this.activeCountryId = selectedCountryId;
  }
  public setActiveBrand(selectedBrandId: number) {
    this.activeProductBrandId = selectedBrandId;
  }

  public getProducts(selectedTypeId: number = 0) {
    this.setActiveProductType(selectedTypeId);
    let productTypeName: string = this.getProductTypeName(selectedTypeId);
    this.shopService.getProducts<IProduct>(productTypeName).subscribe({
      next: result => this.products = result.data,
      error: err => console.log(err)
    });
  }

  public getProductTypes() {
    this.shopService.getProductTypes().subscribe({
      next: result => this.types = result,
      error: err => console.log(err)
    });
  }
  public getProductBrands() {
    this.shopService.getProductBrands().subscribe({
      next: result => this.brands = result,
      error: err => console.log(err)
    });
  }
  public getProductCountries() {
    this.shopService.getProductCountries().subscribe({
      next: result => this.countries = result,
      error: err => console.log(err)
    });
  }

  public reset(): void {
    this.activeProductTypeId = 0;
    this.activeProductBrandId = 0;
    this.activeCountryId = 0;
  }
}
