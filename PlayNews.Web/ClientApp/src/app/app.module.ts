import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { HomeComponent } from './private/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './public/login/login.component';
import { SampleGuard } from './guards/SampleGuard';
import { PrivateComponent } from './private/private.component';
import { PublicComponent } from './public/public.component';
import { DetonadosComponent } from './private/detonados/detonados.component';
import { JogosComponent } from './private/jogos/jogos.component';
import { NoticiasComponent } from './private/noticias/noticias.component';
import { PerfilUsuarioComponent } from './private/perfil-usuario/perfil-usuario.component';
import { ReviewsComponent } from './private/reviews/reviews.component';
import { CriarNoticiaComponent } from './private/noticias/criar-noticia/criar-noticia.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { DataTablesModule } from 'angular-datatables';
import { CriarDetonadoComponent } from './private/detonados/criar-detonado/criar-detonado.component';
import { CriarReviewComponent } from './private/reviews/criar-review/criar-review.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent, 
    PrivateComponent,
    PublicComponent,
    LoginComponent,
    DetonadosComponent,
    JogosComponent,
    NoticiasComponent,
    PerfilUsuarioComponent,
    ReviewsComponent,
    CriarNoticiaComponent,
    CriarReviewComponent,
    CriarDetonadoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    DataTablesModule,
    HttpClientModule,
    AngularEditorModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
    SampleGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
