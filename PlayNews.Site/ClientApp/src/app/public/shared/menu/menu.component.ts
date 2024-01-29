import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  topNoticias: any[] = [];
  dataAtual = new Date();
  slideConfig = { "slidesToShow": 1, "slidesToScroll": 1, "infinite": true, "autoplay": true };
  constructor(private http: HttpClient) {
    this.getLabelsTopNoticias();
  }

  getLabelsTopNoticias() {
    this.http
      .get(
        'https://localhost:7265/Noticia/BuscarLabelsTopNoticias',
    ).subscribe((resp) => {
      this.topNoticias = resp as [];
    });
  }
}
