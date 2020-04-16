import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl, ValidatorFn } from '@angular/forms';
import { Usuario } from '../Models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { stringify } from 'querystring';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-usuario-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css']
})
export class UsuarioRegistroComponent implements OnInit {

  formGroup: FormGroup;
  usuario: Usuario;
  constructor(private usuarioService: UsuarioService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.usuario = new Usuario();
    this.usuario.identificacion = "";
    this.usuario.primerNombre = "";
    this.usuario.segundoNombre = "";
    this.usuario.primerApellido = "";
    this.usuario.segundoAPellido = "";
    this.usuario.telefono = "";
    this.usuario.correoElectronico = "";
    this.usuario.clave = "";

    this.formGroup = this.formBuilder.group({
      identificacion: [this.usuario.identificacion, Validators.required],
      primerNombre: [this.usuario.primerNombre, Validators.required],
      segundoNombre: [this.usuario.segundoNombre],
      primerApellido: [this.usuario.primerApellido, Validators.required],
      segundoAPellido: [this.usuario.segundoAPellido, Validators.required],
      telefono: [this.usuario.telefono, [Validators.required, Validators.minLength(10), Validators.maxLength(12)]],
      correoElectronico: [this.usuario.correoElectronico, [Validators.required, Validators.email]],
      clave: [this.usuario.clave, [Validators.required, Validators.minLength(6)]],
      confirmacionClave: ["", [Validators.required, this.ClaveConfirmada('clave')]]
    });

  }

  get control() {
    return this.formGroup.controls;
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.registrar();
  }

  registrar() {
    this.usuario = this.formGroup.value;
    this.usuarioService.post(this.usuario).subscribe(p => {
      if (p != null) {
        alert('Su registro se ha realizado con exito!');
        this.usuario = p;
      }
    });
  }

  ClaveConfirmada(otherControlName: string): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      const otherControl: AbstractControl = control.root.get(otherControlName);

      if (otherControl && control.value !== otherControl.value) {
        return { claveDiferente: true, messageError: "Las contraseñas no coinciden" };
      }

      return null;
    };
  }

}
