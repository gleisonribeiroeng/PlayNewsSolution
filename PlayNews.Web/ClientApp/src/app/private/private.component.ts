import { Component } from '@angular/core';

@Component({
  selector: 'app-private',
  templateUrl: './private.component.html',
  styleUrls: ['./private.component.css']
})
export class PrivateComponent {
  sidebarVisible: boolean = true;
  menuItems: any[];

  constructor() {
    this.menuItems = [
      {
        label: 'Notícias',
        icon: 'pi pi-fw pi-newspaper',
        command: () => {
          // Lógica para navegar até a página de notícias
        }
      },
      {
        label: 'Reviews',
        icon: 'pi pi-fw pi-star',
        command: () => {
          // Lógica para navegar até a página de reviews
        }
      },
      {
        label: 'Detonados',
        icon: 'pi pi-fw pi-lock',
        command: () => {
          // Lógica para navegar até a página de detonados
        }
      }
    ];
  }
}
