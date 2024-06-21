export interface Mall {
    id:          number;
    name:        string;
    description: string;
    address:     string;
    imageUrl:    string;
    opensAt:     string;
    closesAt:    string;
    shops:       Shop[];
}
   
export interface Shop {
    id:          number;
    mallId:      number;
    name:        string;
    description: string;
    address:     string;
    imageUrl:    string;
    bannerUrl:   string;
    opensAt:     string;
    closesAt:    string;
    categories:  string[];
    menu:        Product[];
    promotions:  any[];
    agentIds:    any[];
}

export interface Product{
    id:          number;
    shopId: number;
    category:    string;
    name:        string;
    description: string;
    price:       number;
    imageUrl:    string;
    isAvailable: boolean;
}
   