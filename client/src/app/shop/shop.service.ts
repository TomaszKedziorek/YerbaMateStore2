import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/IPagination';
import { IProductBrand } from '../shared/models/IProductBrand';
import { ICountry } from '../shared/models/ICountry';
import { IProductType } from '../shared/models/IProductType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getProducts<TProduct>(productTypeName: string = "") {
    productTypeName = productTypeName ? '/' + productTypeName : "";
    return this.http.get<IPagination<TProduct>>(
      `${this.baseUrl}/products${productTypeName}?pageSize=8`);
  }
  
  public getProductBrands() {
    return this.http.get<IProductBrand[]>(this.baseUrl + '/products/brands');
  }

  public getProductTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + '/products/types');
  }

  public getProductCountries() {
    return this.http.get<ICountry[]>(this.baseUrl + '/products/countries');
  }
}