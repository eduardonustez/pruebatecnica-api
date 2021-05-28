import { Inject,Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

const login={
  user:'admin',
  password:"1234",
  token:""
}
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
     //Authorization: ''
  })
};
@Injectable({
  providedIn: 'root'
})
export class FacturaService {
  private cookieStore = {};
  private apiUrl = "https://localhost:44341";
  
  constructor(private http: HttpClient) { 
    login.token = localStorage.getItem('jwt')??"";  

    if(login.token==""){
      this.http.post<any>(`${this.apiUrl}/token`,login,httpOptions).subscribe(
        r=> {
          localStorage.setItem('jwt',r.token.result);
        }
      );
      httpOptions.headers.append('Authorization',login.token);
    }
  }
  public register(request:any): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}/Factura`,request,httpOptions);
  }
  public getFacturas(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Factura`,httpOptions);
  }
  public getProductoById(id:number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Producto/?id=${id}`,httpOptions);
  }
  

}
