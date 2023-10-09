import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/IPagination';
import { IProductBrand } from '../shared/models/IProductBrand';
import { ICountry } from '../shared/models/ICountry';
import { IProductType } from '../shared/models/IProductType';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getProducts<TProduct>(productTypeName?: string, brandId?: number, countryId?: number, sort?: string) {
    let endpoint: string = productTypeName ? `products/${productTypeName}` : 'products';
    let params = this.setApiQueryParams(brandId, countryId, sort);
    return this.http.get<IPagination<TProduct>>(this.baseUrl + endpoint, { observe: 'response', params: params })
      .pipe(
        map(response => {
          return response.body;
        }));
  }

  private setApiQueryParams(brandId?: number, countryId?: number, sort?: string): HttpParams {
    let params = new HttpParams();
    if (brandId) { params = params.append('brandId', brandId.toString()) }
    if (countryId) { params = params.append('countryId', countryId.toString()) }
    if (sort) { params = params.append('sort', sort) }
    return params;
  }

  public getProductBrands() {
    return this.http.get<IProductBrand[]>(this.baseUrl + 'products/brands');
  }

  public getProductTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'products/types');
  }

  public getProductCountries() {
    return this.http.get<ICountry[]>(this.baseUrl + 'products/countries');
  }
}