import { Product } from "./malls";

export interface ResposeSearchFood {
    address:             string;
    bannerUrl:           string;
    categories:          string[];
    description:         string;
    imageUrl:            string;
    mallId:              number;
    menuFilteredResults: Product[];
    name:                string;
    shopId:              number;
}
