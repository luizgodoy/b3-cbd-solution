import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { CdbService } from '../../services/cdb.service';  

@Component({
  selector: 'app-calculate',
  templateUrl: './calculate.component.html',
  styleUrls: ['./calculate.component.css']
})
export class CalculateComponent implements OnInit {
  
  cdbForm : any;
  
  valorBruto : string | undefined;
  valorLiquido : string | undefined;
  observacao : string | undefined;

  constructor(private formbulider: FormBuilder, private cdbService:CdbService)  {}

  ngOnInit() : void {    
    this.cdbForm = this.formbulider.group({  
      Principal: ['', [Validators.required]],  
      Vencimento: ['', [Validators.required]],  
    });  
  }

  onFormSubmit() : void {
    this.getCdb(this.cdbForm.get('Principal').value, this.cdbForm.get('Vencimento').value);
  }

  getCdb(principal : number, vencimento : number) : void
  {
      this.cdbService.getCdb(principal, vencimento).subscribe(item => {
      this.valorBruto = item.ValorBruto;
      this.valorLiquido = item.ValorLiquido;
      this.observacao = item.Status;
    },
    error => {
        this.observacao = 'Falha ao chamar o servico, tente novamente!';
      }
    );   

  }

  resetForm() : void {  
    this.cdbForm.reset();     
  }
}