import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CalculateComponent } from './views/calculate/calculate.component';

const routes: Routes = [
  {
    path: "",
    component: CalculateComponent
  },
  {
    path: "calculate",
    component: CalculateComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
