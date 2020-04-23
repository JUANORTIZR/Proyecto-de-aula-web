import { Component, OnInit } from '@angular/core';
import { Usuario } from '../Models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-usuario-consulta',
  templateUrl: './usuario-consulta.component.html',
  styleUrls: ['./usuario-consulta.component.css']
})
export class UsuarioConsultaComponent implements OnInit {

  usuarios:Usuario[];
  constructor(private usuarioService:UsuarioService) { }

  ngOnInit() {
    this.usuarioService.get().subscribe(result=>{
      this.usuarios = result;
    });
  }

}
