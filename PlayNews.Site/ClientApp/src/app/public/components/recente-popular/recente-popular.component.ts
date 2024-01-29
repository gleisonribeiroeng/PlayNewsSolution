import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-recente-popular',
  templateUrl: './recente-popular.component.html',
  styleUrls: ['./recente-popular.component.css']
})
export class RecentePopularComponent {

  constructor(private http: HttpClient) {
    this.getRecentes();
  }

  getRecentes() {
    this.http
      .get(
        'https://localhost:7265/RecentePopular/BuscarRecentesPopular',
      ).subscribe((resp) => {
        console.log(resp);
      });
  }
}
