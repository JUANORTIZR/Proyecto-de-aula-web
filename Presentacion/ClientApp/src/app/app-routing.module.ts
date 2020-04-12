import { UsuarioRegistroComponent } from './logisticaDelSinu/usuario-registro/usuario-registro.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
    {
    path: 'UsuarioRegistro',
    component: UsuarioRegistroComponent
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
