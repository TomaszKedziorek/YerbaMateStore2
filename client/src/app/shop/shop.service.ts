import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPagination } from '../shared/models/IPagination';
import { IProduct } from '../shared/models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getProducts<TProduct>() {
    return this.http.get<IPagination<TProduct>>(this.baseUrl + '/products?pageSize=50');
  }
}