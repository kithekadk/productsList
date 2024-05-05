export interface Product{
    id: string
    name: string
    description: string
    price: number
    imageUrl: string
}

export interface ProductWithFactorial extends Product{
    row: number
    factorial: number
}