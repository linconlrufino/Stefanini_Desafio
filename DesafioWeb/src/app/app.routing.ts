import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CidadeComponent } from './cidade/cidade.component';
import { MenuComponent } from './menu/menu.component';
import { PessoaComponent } from './pessoa/pessoa.component';

const routes: Routes = [
  {
    path: '',
    component: MenuComponent,
  },
  {
    path: 'pessoa',
    component: PessoaComponent,
  },
  {
    path: 'cidade',
    component: CidadeComponent,
  },
];

export const routing: ModuleWithProviders<any> = RouterModule.forRoot(routes);
