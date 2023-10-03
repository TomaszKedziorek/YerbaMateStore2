import { IProduct } from "./IProduct"

export interface IYerbaMate extends IProduct {
  composition: string
  hasAdditives: boolean
  weight: string
  brand: string
  country: string
  countryCode: string
}