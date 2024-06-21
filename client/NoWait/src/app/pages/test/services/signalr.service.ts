import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private connection: HubConnection;

  constructor() {
    console.log('conectando con signalr');
    this.connection = new HubConnectionBuilder()
      .withUrl('https://s14.runasp.net/order-pos-hub', {
        accessTokenFactory: () => "CfDJ8BUAI6dB3fJOskpHyYF0_2iJ4GOIYHxPwVDWjeNNFk0wwQ6Gn6GOTN3TdXZPPt1hhScwnd1Fm9ZbitjfMDxcpb0_a1x2ZJjW55T5BnUm0fL-tx0_k87JXNfi-RVNhj_gB0nDV6tDDlcECXAH6AjFPs5ST5zEnDvHNC9X-M5OEBYjkXjdFdl7tVlbZz_oGpRMthfFmqvleauty-TYyJbt_fwYpYfnNuyUIQ4tA3fNH2TgO_d6MaF6i5WMdGNSke_g3BdEt4EdOjys25c2QNMvdax5oL6Y3SDut_5e_unsUm4JZAKZ6eC-1B4o7rPOlBHGP7CgsCxk-DDCnBOfYnWwCUNSaof34UAaKsd4oZ7NtmcMLleeD5nQQzI-QFDkvnFQgWCqZ1sSq6JZzECHjiL2LDhxZDQN32cmzkF7qbaa4NCe7i0O1UzuyHYZu22BUpMC8NOoVpYr85sBa8Mw1ICb9V7y8G2qWiQZnbVcikeGIlZmL-Wl5OhK72sbVkRtGC7VG1Yb2uraBNVLO5iEySEVj29U2dL8N-JqMk00J1n4bCIywGLOyt0wlMFnxkf-ZTueuhX8_KslOzuDvjb0R1XLFeFAjLwQfFYkPTC80EL7V4-5Gsaw4af8d3q8z-5Hq4PdfQG3r51RPCAiLrFJIfEnIVo"
      })
      .build();



    this.connection.on("Test", (message) => {
      console.log(message)
    })
    this.connection.on("Test", (email, nro, status) => {
      console.log(email)
      console.log(nro)
      console.log(status)
    })

    this.connection.start().then(() => {
      console.log('Conexión establecida con éxito');
    }).catch(err => {
      console.error('Error al conectar:', err);
    });

  }
}
