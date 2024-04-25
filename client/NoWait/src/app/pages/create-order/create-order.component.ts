import { Component, OnInit, inject, signal } from '@angular/core';
import { LoadingModalComponent } from '../../shared/components/modals/loading-modal/loading-modal.component';
import { OrderService } from '../../shared/services/order.service';
import { DetailOrder } from '../../models/orders';
import { ShoppingCartManagerService } from '../../shared/services/shopping-cart-manager.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-order',
  standalone: true,
  imports: [LoadingModalComponent],
  templateUrl: './create-order.component.html',
  styleUrl: './create-order.component.css'
})
export class CreateOrderComponent implements OnInit {
  private _orderService = inject(OrderService);
  private _cartManage = inject(ShoppingCartManagerService);
  private router = inject(Router);

  showLoadingModal = signal<boolean>(true)

  message = "Creando Orden..."

  messageResul = signal<string>('')

  detailOrderList: DetailOrder[] = [];

  ngOnInit(): void {
    this.detailOrderList = this._cartManage.cartContent()
      .map(item => {
        return { quantity: item.amount, price: item.price, productId: item.id } as DetailOrder
      })

    if (this.detailOrderList.length !== 0) {
      this._orderService.createOrder({ localId: 1, items: this.detailOrderList })
        .subscribe(
          {
            next: (res) => {
              console.log(res)

              // TODO: cambiar al id verdadero
              this.payOrder(res)

            },
            error: () => {
              this.messageResul.set('OOOPP!!. No se pudo crear la Orden')
              this.showLoadingModal.set(false)
            }
          }
        )
    }
    else {
      this.router.navigateByUrl("/")
    }
  }

  payOrder(orderId: number) {
    this.showLoadingModal.set(true)
    this.message = 'Pagando Orden...'
    this._orderService.payOrder(orderId)
      .subscribe({
        next: (res) => {
          if (res.isValid) {
            this.messageResul.set('Orden creada y pagada con exito')
            this.showLoadingModal.set(false)
            this._cartManage.toEmptyCart()
            return
          }
          this.messageResul.set('OOOPP!!. No se pudo pagar la Orden');
          this.showLoadingModal.set(false);
        },
        error: () => {
          this.messageResul.set('OOOPP!!. No se pudo pagar la Orden')
          this.showLoadingModal.set(false)
        },
        complete: () => {
          this.showLoadingModal.set(false)
        }
      })
  }

  goHome() {
    this.router.navigateByUrl('/')
  }
}
