import { Component } from '@angular/core';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-registrar',
  standalone: true,
  imports: [ReactiveFormsModule, MatSelectModule, MatButtonModule],
  templateUrl: './registrar.component.html',
  styleUrl: './registrar.component.css'
})
export class RegistrarComponent {

  formSolicitud: FormGroup;
  libroId: number = 0;
  libros: any[] = [
    { id: 0, titulo: "---SELECCIONE--" },
    { id: 1, titulo: "ABC" },
    { id: 2, titulo: "100 años de soledad"},
    { id: 3, titulo: "Alicia en el pais de las maravillas"},
    { id: 4, titulo: "Harry Potter"},
    { id: 5, titulo: "El señor de los anillos"},
    { id: 6, titulo: "Historia de 2 ciudades"},
    { id: 7, titulo: "El principito"}
  ];

  constructor(private fb: FormBuilder) {
    this.formSolicitud = this.fb.group({
      libroId: ['0']
    });
  }

  registrar() {
    const libroId = this.formSolicitud.get('libroId')?.value;

    if(!libroId)
      alert("Debe seleccionar un libro");

    const data = {
      idUsuarioSolicitante: 1,
      libroId: 1
    };

    fetch('https://localhost:7065/api/prestamos', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    })
      .then(response => response.json())
      .then(data => {
        alert("registrado");

        console.log(data);
      })
      .catch(error => console.error('Error:', error));

    
  }

}
