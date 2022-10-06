import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Pessoa } from '../models/pessoa';
import { PessoaService } from '../services/pessoa.service';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {

  public mode: string = 'list';
  public pessoa = {} as Pessoa;
  public pessoas: Pessoa[] = [];

  constructor(private pessoaService: PessoaService, fb: FormBuilder) {

  }

  ngOnInit(): void {
    this.getPessoas();
  }

  savePessoa(form: NgForm) {
    if (this.pessoa.id !== undefined) {
      this.pessoaService.updatePessoa(this.pessoa).subscribe(() => {
        this.cleanForm(form);
      });
    } else {
      this.pessoaService.savePessoa(this.pessoa).subscribe(() => {
        this.cleanForm(form);
      });
    }
  }

  getPessoas() {
    this.pessoaService.getPessoas().subscribe((pessoas: Pessoa[]) => {
      this.pessoas = pessoas;
    });
  }

  deletePessoa(pessoa: Pessoa) {
    this.pessoaService.deletePessoa(pessoa).subscribe(() => {
      this.getPessoas();
    });
  }

  editPessoa(pessoa: Pessoa) {
    this.pessoa = { ...pessoa };
  }

  cleanForm(form: NgForm) {
    this.getPessoas();
    form.resetForm();
    this.pessoa = {} as Pessoa;
  }
}
