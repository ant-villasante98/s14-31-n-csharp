export interface Payment{
    orderId:     number;
    paymentDate: Date;
    errors:      PaymentError[];
    isValid:     boolean;
}

export interface PaymentError{
    id:          number;
    code:        string;
    description: string;
}