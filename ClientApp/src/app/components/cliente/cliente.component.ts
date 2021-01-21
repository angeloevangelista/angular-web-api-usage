import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ClienteService } from "src/app/services/cliente.service";
import { ICliente } from "src/models/Cliente";

@Component({
  selector: "app-cliente-component",
  templateUrl: "./cliente.component.html",
})
export class ClienteComponent implements OnInit {
  clientes: ICliente[];
  cliente: ICliente;

  formTitle: string;
  form: FormGroup;
  editing = false;

  constructor(
    private clienteService: ClienteService,
    private formBuilder: FormBuilder
  ) {
    this.form = this.formBuilder.group({
      nome: ["", Validators.required],
      endereco: ["", Validators.required],
      cidade: ["", Validators.required],
      email: ["", Validators.required],
    });

    this.formTitle = "Adicionar cliente";
  }

  handleCancel(event: Event) {
    event.preventDefault();

    this.editing = false;
    this.formTitle = "Adicionar cliente";

    this.form.reset();
  }

  handleSubmit() {
    this.cliente = { ...this.cliente, ...this.form.value };

    if (this.editing) {
      this.clienteService.updateCliente(this.cliente).subscribe({
        next: (value) => {
          this.clientes = this.clientes.map((cli) =>
            cli.id === value.id ? value : cli
          );

          this.editing = false;
          this.form.reset();
        },
      });
    } else {
      this.clienteService.saveCliente(this.cliente).subscribe({
        next: (value) => {
          this.clientes.push(value);
          this.form.reset();
        },
      });
    }

    this.cliente = null;
  }

  handleEdit(clienteData: ICliente) {
    this.editing = true;
    this.cliente = clienteData;
    this.formTitle = `Editando cliente: ${clienteData.nome}`;

    this.form.setValue({
      nome: this.cliente.nome,
      endereco: this.cliente.endereco,
      cidade: this.cliente.cidade,
      email: this.cliente.email,
    });
  }

  getClientes() {
    this.clienteService.getClientes().subscribe({
      next: (value) => (this.clientes = value),
      error: (err) => {
        alert("Erro");
        console.warn(err);
      },
      complete: () => console.log(this.clientes),
    });
  }

  deleteCliente(cliente_id: number) {
    this.clienteService.deleteCliente(cliente_id).subscribe({
      next: (value) => {
        this.clientes = this.clientes.filter((cli) => cli.id !== value.id);
      },
      error: (err) => {
        alert("Erro");
        console.warn(err);
      },
      complete: () => console.log(this.clientes),
    });
  }

  ngOnInit(): void {
    this.getClientes();
  }
}
