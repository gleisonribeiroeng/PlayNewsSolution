import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-criar-detonado',
  templateUrl: './criar-detonado.component.html',
  styleUrls: ['./criar-detonado.component.css']
})
export class CriarDetonadoComponent {
  htmlContent: any;
  base64textString: String = "";
  imagem: any;
  titulo: string = '';
  subTitulo: string = '';
  jogo = null;
  manchete: boolean = false;
  indiceCapaSelecionada: number = 0;

  listaImagens: any[] = [];
  listaJogos: any[] = [];

  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: 'auto',
    minHeight: '0',
    maxHeight: 'auto',
    width: 'auto',
    minWidth: '0',
    translate: 'yes',
    enableToolbar: true,
    showToolbar: true,
    placeholder: 'Enter text here...',
    defaultParagraphSeparator: '',
    defaultFontName: '',
    defaultFontSize: '',
    fonts: [
      { class: 'arial', name: 'Arial' },
      { class: 'times-new-roman', name: 'Times New Roman' },
      { class: 'calibri', name: 'Calibri' },
      { class: 'comic-sans-ms', name: 'Comic Sans MS' }
    ],
    customClasses: [
      {
        name: 'quote',
        class: 'quote',
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: 'titleText',
        class: 'titleText',
        tag: 'h1',
      },
    ],
    uploadWithCredentials: false,
    sanitize: true,
    toolbarPosition: 'top',
    toolbarHiddenButtons: [
      ['bold', 'italic'],
      ['fontSize']
    ]
  };

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.getJogos();
  }

  adicionarImagens() {
    this.listaImagens.push({ capa: false, nome: this.imagem, data: this.base64textString });
    this.imagem = null;
  }

  handleFileSelect(evt: any) {
    var files = evt.target.files;
    var file = files[0];

    if (files && file) {
      var reader = new FileReader();

      reader.onload = this._handleReaderLoaded.bind(this);

      reader.readAsBinaryString(file);
    }
  }

  _handleReaderLoaded(readerEvt: any) {
    var binaryString = readerEvt.target.result;
    this.base64textString = btoa(binaryString);
  }

  getJogos() {
    this.http
      .get(
        'https://localhost:44301/Detonado/BuscarJogos',
      ).subscribe((resp) => {
        console.log(resp);
        this.listaJogos = resp as any[];
      });
  }

  validarForm(): boolean {
    if (this.titulo
      && this.subTitulo
      && this.jogo
      && this.listaImagens.length
      && this.htmlContent)
      return true;
    else
      return false;
  }


  salvar() {
    this.listaImagens[this.indiceCapaSelecionada].capa = true;
    this.http
      .post(
        'https://localhost:44301/Detonado/CriarDetonado', {
        titulo: this.titulo,
        subTitulo: this.subTitulo,
        idJogo: this.jogo,
        manchete: this.manchete,
        corpo: this.htmlContent,
        imagens: this.listaImagens
      }
      ).subscribe((resp) => {
        console.log(resp);
        if ((resp as any).sucesso) {
          Swal.fire({
            title: 'Sucesso',
            text: 'Detonado salvo com sucesso',
            icon: 'success',
            confirmButtonText: 'OK',
            customClass: {
              confirmButton: 'botao-confirmacao'
            }
          }).then((result) => {
            if (result.isConfirmed) {
              this.router.navigate(['/detonados']); // Navegar para outra tela
            }
          });
        } else {
          Swal.fire({
            title: 'Erro',
            text: 'Erro ao salvar o detonado',
            icon: 'error',
            confirmButtonText: 'OK'
          });
        }


      });
  }
}
