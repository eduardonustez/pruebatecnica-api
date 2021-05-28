import { state } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FacturaService } from 'src/app/shared/services/factura.service';


@Component({
  selector: 'app-facturaviewer',
  templateUrl: './facturaviewer.component.html',
  styleUrls: ['./facturaviewer.component.css']
})
export class facturaViewerComponent implements OnInit {
    public facturas: Array<any> = [];
    
  constructor(private apiService:FacturaService) { 

  }

  ngOnInit(): void {
   this.apiService.getFacturas().subscribe(response => (this.facturas = response));   
  }
}
