import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RegistrarComponent } from './solicitud/registrar/registrar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RegistrarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'app-biblioteca';
}
