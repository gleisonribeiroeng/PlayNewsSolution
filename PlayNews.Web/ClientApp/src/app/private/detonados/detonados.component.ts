import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-detonados',
  templateUrl: './detonados.component.html',
  styleUrls: ['./detonados.component.css']
})
export class DetonadosComponent {
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
          title: 'Titulo', data: 'titulo', render: function (data, type, row, meta) {
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
          title: 'SubTitulo', data: 'subTitulo', render: function (data, type, row, meta) {
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
          title: 'Data Publicação', data: 'dataPublicacao', render: function (data, type, row, meta) {
            const dia = String(new Date(data).getDate()).padStart(2, '0');
            const mes = String(new Date(data).getMonth() + 1).padStart(2, '0');
            const ano = String(new Date(data).getFullYear());

            return `${dia}/${mes}/${ano}`;
          }
        },

        {
          title: 'Manchete', data: 'manchete', render: function (data, type, row, meta) {
            return data ? 'Sim' : 'Não';
          }
        },
        { title: 'Jogo', data: 'nomeJogo' },
        { title: 'Autor', data: 'nomeUsuario' }
      ],
      columnDefs: [
        { targets: 0, width: '25px' },
        { targets: 1, width: '250px' },
        { targets: 2, width: '250px' },
        { targets: 3, width: '150px' },
        { targets: 4, width: '25px' },
        { targets: 5, width: '150px' },
        { targets: 6, width: '100px' }
      ],
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .get(
            'https://localhost:44301/Detonado/BuscarDetonados',
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
