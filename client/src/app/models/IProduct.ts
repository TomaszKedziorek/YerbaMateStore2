import { IImage } from "./IImage";

export interface IProduct {
  id: number
  name: string
  description: string
  price: number
  quantity: number
  images: IImage[]
  productType: string
}