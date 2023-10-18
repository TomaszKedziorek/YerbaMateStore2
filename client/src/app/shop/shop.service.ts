import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/IPagination';
import { IProductBrand } from '../shared/models/IProductBrand';
import { ICountry } from '../shared/models/ICountry';
import { IProductType } from '../shared/models/IProductType';
import { map } from 'rxjs';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getProducts<TProduct>(shopParams: ShopParams, productTypeName?: string) {
    let endpoint: string = productTypeName ? `products/${productTypeName}` : 'products';
    let params = this.setApiQueryParams(shopParams);
    return this.http.get<IPagination<TProduct>>(this.baseUrl + endpoint, { observe: 'response', params: params })
      .pipe(
        map(response => {
          return response.body;
        }));
  }

  private setApiQueryParams(shopParams: ShopParams): HttpParams {
    let params = new HttpParams();
    if (shopParams.search) { params = params.append('search', shopParams.search) }
    if (shopParams.brandId) { params = params.append('brandId', shopParams.brandId.toString()) }
    if (shopParams.countryId) { params = params.append('countryId', shopParams.countryId.toString()) }
    if (shopParams.sort) { params = params.append('sort', shopParams.sort) }
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());
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