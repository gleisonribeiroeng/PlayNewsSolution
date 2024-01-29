import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-manchete',
  templateUrl: './manchete.component.html',
  styleUrls: ['./manchete.component.css']
})
export class MancheteComponent {
  ultimasManchetes: any[] = [];
  constructor(private http: HttpClient) {
    this.getManchetes();
  }

  getManchetes() {
    this.http
      .get(
        'https://localhost:7265/Noticia/BuscarUltimasManchetes',
    ).subscribe((resp) => {
      this.ultimasManchetes = resp as [];
      });
  }
}
