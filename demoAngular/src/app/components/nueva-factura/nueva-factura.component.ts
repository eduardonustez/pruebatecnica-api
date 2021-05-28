import { Component, OnInit } from '@angular/core';
import { FacturaService } from 'src/app/shared/services/factura.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-nueva-factura',
  templateUrl: './nueva-factura.component.html',
  styleUrls: ['./nueva-factura.component.css']
})
export class nuevaFacturaComponent implements OnInit {
  public itemsArray: Array<any> = [];
  public newItem: any = {};
  public registerDisabled=true;
  public currentUser="";
  constructor(private apiService:FacturaService,private router: Router) 
  { 

  }

  ngOnInit(): void {
  }

  addItem() {
      this.itemsArray.push(this.newItem)
      this.newItem = {};
      this.registerDisabled=false;
  }

  deleteItem(index:number) {
      this.itemsArray.splice(index, 1);
      if(this.itemsArray.length==0)
        this.registerDisabled=true;
  }
  focusOutFunction(event:any){
    this.apiService.getProductoById(event.target.value).subscribe(response => {
      this.newItem = response;
      this.newItem.cantidad=1;
      this.newItem.subtotal=this.newItem.precio;
    });   
  }
  changeFunction(event:any){
    var cantidad = event.target.value;
    this.newItem.subtotal = this.newItem.precio * cantidad;
    this.newItem.valorDescuento = this.newItem.precio * this.newItem.cantidad * this.newItem.descuento /100;
    this.newItem.valorIVA = this.newItem.precio * this.newItem.cantidad * this.newItem.iva /100;
    this.newItem.total = this.newItem.subtotal - this.newItem.valorDescuento + this.newItem.valorIVA;
  }

  register(){
   let newFactura:any={
      tipoDePago:1,
      numeroDocumento:this.currentUser,
      items : this.itemsArray
    };
    this.apiService.register(newFactura).subscribe(r=>console.log(r));
    this.router.navigate(['/'])
  }

}
