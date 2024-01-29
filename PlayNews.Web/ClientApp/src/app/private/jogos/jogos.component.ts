import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.css']
})
export class JogosComponent {
  dtOptions: DataTables.Settings = {};

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.dtOptions = {
      autoWidth: true,
      searching: false,
      serverSide: true,
      language: {
        "lengthMenu": "Mostrando _MENU_ noticias por página",
        "zeroRecords": "Nenhuma noticia encontrada",
        "info": "Mostrando _PAGE_ de _PAGES_ noticias",
        "infoEmpty": "Nenhuma noticia encontrada",
        "infoFiltered": "(filtrado de _MAX_ noticias)",
        "paginate": {
          "first": "Primeira",
          "last": "Ultima",
          "previous": "Anterior",
          "next": "Próximo"
        }
      },
      columns: [
        { title: 'Codigo', data: 'id' },
        {
          title: 'Nome', data: 'nome', render: function (data, type, row, meta) {
            if (type === 'display') {
              var texto = data;
              if (texto.length > 30) {
                texto = texto.substring(0, 30) + '...';
              }
              return texto;
            }
            return data;
          }
        },
        {
          title: 'Ano', data: 'ano'
        },
        {
          title: 'Categorias', data: 'categorias', render: function (data, type, row, meta) {
            if (type === 'display') {
              var texto = data;
              if (texto.length > 30) {
                texto = texto.substring(0, 30) + '...';
              }
              return texto;
            }
            return data;
          }
        },
      ],
      columnDefs: [
        { targets: 0, width: '25px' },
        { targets: 1, width: '250px' },
        { targets: 2, width: '250px' },
        { targets: 3, width: '350px' }
      ],
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .get(
            'https://localhost:44301/Jogo/BuscarJogos',
          ).subscribe((resp) => {
            console.log(resp)
            callback({
              recordsTotal: (resp as any[]).length,
              recordsFiltered: 10,
              data: resp
            });
          });
      }
    };
  }

}
