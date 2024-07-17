import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PersonService, PersonModel } from '../services/person.service';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { FormBuilder, FormGroup, ReactiveFormsModule, FormsModule, Validators } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { jsPDF } from 'jspdf';
import autoTable from 'jspdf-autotable';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, 
            RouterOutlet, 
            MatTableModule,
            MatIconModule,
            MatPaginatorModule, 
            MatFormFieldModule, 
            MatInputModule, 
            ReactiveFormsModule, 
            FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, AfterViewInit {
  title = 'cartsys-frontend';

  displayedColumns: string[] = ['name', 'age', 'address', 'email', 'actions'];
  dataSource = new MatTableDataSource<PersonModel>();

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  personForm: FormGroup;

  constructor(private fb: FormBuilder, private personService: PersonService) {
    this.personForm = this.fb.group({
      name: ['', Validators.required],
      age: ['', [Validators.required, Validators.min(0)]],
      address: [''],
      email: ['', [Validators.email]]
    });
  }

  ngOnInit(): void {
    this.loadingTable();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.paginator.pageSize = 4; 
  }

  onSubmit(): void {
    if (this.personForm.valid) {
      this.personService.createPerson(this.personForm.value).subscribe(data => {
        this.loadingTable();
      })   
    }
  }  

  loadingTable(): void {
    this.personService.getAllPersons().subscribe(data => {
      this.dataSource.data = data;
    });
  }

  deletePerson(person: PersonModel): void {
    this.personService.deletePerson(person.id).subscribe(data => {
      this.loadingTable(); // Atualiza a tabela após deletar o registro
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  generateReport(): void {
    const doc = new jsPDF();
    const col = ["Nome", "Idade", "Endereço", "Email"];
    const rows: any[] = [];

    this.dataSource.data.forEach(element => {
      const temp = [element.name, element.age, element.address, element.email];
      rows.push(temp);
    });

    autoTable(doc, {
      head: [col],
      body: rows,
      startY: 10,
    });

    doc.save('relatorio.pdf');
  }
}
