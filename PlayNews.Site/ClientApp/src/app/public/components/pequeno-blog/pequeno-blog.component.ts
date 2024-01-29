import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-pequeno-blog',
  templateUrl: './pequeno-blog.component.html',
  styleUrls: ['./pequeno-blog.component.css']
})
export class PequenoBlogComponent {
  ultimasAnalises: any[] = [];
  constructor(private http: HttpClient) {
    this.getAnalises();
  }

  getAnalises() {
    this.http
      .get(
        'https://localhost:7265/Analise/BuscarUltimasAnalises',
      ).subscribe((resp) => {
        console.log(resp);
        this.ultimasAnalises = resp as [];
      });
  }
}
