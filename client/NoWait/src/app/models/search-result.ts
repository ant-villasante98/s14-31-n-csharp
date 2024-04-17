
export interface ResposeSearchFood {
    address: string;
    bannerUrl: string;
    description: string;
    imageUrl: string;
    mallId: number;
    menuFilteredResults: MenuFilteredResult[];
    name: string;
    shopId: number;
}

export interface MenuFilteredResult {
    category: string;
    description: string;
    id: number;
    imageUrl: string;
    isAvailable: boolean;
    name: string;
    price: number;
}
