import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Cidade } from '../models/cidade';
import { CidadeService } from '../services/cidade.service';

@Component({
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css']
})
export class CidadeComponent implements OnInit {
  public mode: string = 'list';
  public cidade = {} as Cidade;
  public cidades: Cidade[] = [];
  public form: FormGroup;

  constructor(private cidadeService: CidadeService, fb: FormBuilder) {
    this.form = fb.group({
      nome: ['', Validators.compose([
        Validators.required
      ])],
      uf: ['', Validators.compose([
        Validators.minLength(1),
        Validators.max(2),
        Validators.required
      ])]
    });
  }

  ngOnInit(): void {
    this.getCidades();
  }

  saveCidade(form: NgForm) {
    if (this.cidade.id !== undefined) {
      this.cidadeService.updateCidade(this.cidade).subscribe(() => {
        this.cleanForm(form);
      });
    } else {
      this.cidadeService.saveCidade(this.cidade).subscribe(() => {
        this.cleanForm(form);
      });
    }
  }

  getCidades() {
    this.cidadeService.getCidades().subscribe((cidades: Cidade[]) => {
      this.cidades = cidades;
    });
  }

  deleteCidade(cidade: Cidade) {
    this.cidadeService.deleteCidade(cidade).subscribe(() => {
      this.getCidades();
    });
  }

  editCidade(cidade: Cidade) {
    this.cidade = { ...cidade };
  }

  cleanForm(form: NgForm) {
    this.getCidades();
    form.resetForm();
    this.cidade = {} as Cidade;
  }

  changeMode(mode: string) {
    this.mode = mode;
  }

}
