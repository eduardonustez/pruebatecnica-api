import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import{nuevaFacturaComponent} from './components/nueva-factura/nueva-factura.component';
import{facturaViewerComponent} from './components/facturaviewer/facturaviewer.component';

const routes: Routes = [
  { path: 'new', component: nuevaFacturaComponent},
  {path: '', component: facturaViewerComponent} 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
