import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-ultimas-noticias',
  templateUrl: './ultimas-noticias.component.html',
  styleUrls: ['./ultimas-noticias.component.css']
})
export class UltimasNoticiasComponent {
  ultimasNoticias: any[] = [];
  ultimaNoticia: any = null;
  constructor(private http: HttpClient) {
    this.getNoticias();
  }

  getNoticias() {
    this.http
      .get(
        'https://localhost:7265/Noticia/BuscarUltimasNoticias',
      ).subscribe((resp) => {
        console.log(resp);
        this.ultimasNoticias = resp as [];
        this.ultimaNoticia = this.ultimasNoticias[0];
        this.ultimasNoticias.shift();
      });
  }
}
