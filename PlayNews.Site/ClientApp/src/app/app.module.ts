import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './public/pages/home/home.component';
import { MenuComponent } from './public/shared/menu/menu.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { UltimasNoticiasComponent } from './public/components/ultimas-noticias/ultimas-noticias.component';
import { MancheteComponent } from './public/components/manchete/manchete.component';
import { PequenoBlogComponent } from './public/components/pequeno-blog/pequeno-blog.component';
import { RedesSociaisComponent } from './public/components/redes-sociais/redes-sociais.component';
import { RecentePopularComponent } from './public/components/recente-popular/recente-popular.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    MancheteComponent,
    UltimasNoticiasComponent,
    PequenoBlogComponent,
    RedesSociaisComponent,
    RecentePopularComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent },
    ]),
    SlickCarouselModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
