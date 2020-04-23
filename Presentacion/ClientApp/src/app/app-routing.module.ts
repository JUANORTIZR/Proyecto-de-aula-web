import { UsuarioRegistroComponent } from './logisticaDelSinu/usuario-registro/usuario-registro.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioConsultaComponent } from './LogisticaDelSinu/usuario-consulta/usuario-consulta.component';


const routes: Routes = [
    {
    path: 'UsuarioRegistro',
    component: UsuarioRegistroComponent
    },
  {
    path: 'UsuarioConsulta',
    component:UsuarioConsultaComponent
  }
]  

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
