import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PhoneBookComponent } from './phone-book/phone-book.component';

export const routes: Routes = [
  {
    path: '',
    component: PhoneBookComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PhoneBookRoutingModule {}
