import { IProduct } from "./IProduct"

export interface IBombilla extends IProduct {
  material: string
  length: string
  isUnscrewed: boolean
}
