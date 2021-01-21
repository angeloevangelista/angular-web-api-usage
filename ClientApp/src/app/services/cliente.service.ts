import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { ICliente } from "src/models/Cliente";

@Injectable({ providedIn: "root" })
export class ClienteService {
  constructor(private http: HttpClient) {}

  getClientes() {
    return this.http.get<ICliente[]>("api/clientes");
  }

  saveCliente(cliente: Partial<ICliente>) {
    return this.http.post<ICliente>("api/clientes", cliente);
  }

  updateCliente(cliente: ICliente) {
    return this.http.put<ICliente>(`api/clientes/${cliente.id}`, cliente);
  }

  deleteCliente(cliente_id: number) {
    return this.http.delete<ICliente>(`api/clientes/${cliente_id}`);
  }
}
