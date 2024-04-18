export interface CreateOrder{
    localId: number;
    items: DetailOrder[];
}

export interface DetailOrder{
    productId: number;
    quantity: number;
    price: number;
}

export interface Order{
    id: number;
    creationDate: Date;
    status: OrderStatus;
    details: DetailOrder[];
    historyState: HistoryState[];
}

export interface HistoryState{
    date: Date;
    status: OrderStatus;
}

export enum OrderStatus{
    Created = 0,
    Payed = 1,
    InProgress = 2,
    Prepared = 3,
    Finished = 4,
    Canceled = 5
}