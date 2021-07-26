import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Person } from 'src/app/core/person';
import { PeopleService } from 'src/app/modules/home/services/people.service';

const DNA_CHARACTER = [ 'A', 'T', 'C','G' ];

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  @Output() reload = new EventEmitter<any>();

  formPerson:FormGroup;
  errorDna = [null, null, null, null, null, null];
  error = true;

  constructor(private modal: NgbActiveModal,
    private formBuilder:FormBuilder,
    private peopleService:PeopleService) { }

  ngOnInit() {
    this.initializeForm();
  }

  onSubmit(){
    this.create();
    this.modal.dismiss('confirm click');
  }

  initializeForm(){
    this.formPerson = this.formBuilder.group({
      name:[null,[Validators.required]],
      country:[null,[Validators.required]],
      dnas: this.formBuilder.array([])
    });

    this.addDna();

  }

  get dnas(){
    return this.formPerson.get('dnas') as FormArray;
  }


  addDna(){
    for(let i = 0; i < 6; i++){
      this.formPerson.controls.dnas['controls'].push(
        this.formBuilder.control(null)
        );
    }
   
  }

  create(){
    let i = 0;

    this.formPerson.controls.dnas['controls'].forEach(x=>{
      this.formPerson.value.dnas[i] = (x.value);
      i++;
    });

    let person:Person = new Person(this.formPerson.value);

    this.peopleService.insertPerson(person).subscribe(item => {
      this.reload.emit(true);
    });
    
  }


  validate(i){

    let dna = this.formPerson.controls.dnas['controls'][i].value;

    this.errorDna[i] = null;

    if(dna == null){
      this.error = true;
      this.errorDna[i] = "El adn es requerido";
      return;
    }

    dna = dna.toUpperCase();
    this.formPerson.controls.dnas['controls'][i].setValue(dna);


    if(dna.length != 6){
      this.error = true;
      this.errorDna[i] = "El adn debe tener 6 caracteres";
      return;
    }

    let dnaArray = dna.split('');

    dnaArray.forEach(item=>{
      if(DNA_CHARACTER.indexOf(item) < 0){
        this.error = true;
        this.errorDna[i] = "El adn debe contener solo las letras A, T , C , G";
        return;
      }
    });


    if(this.errorDna[i] != null)
      return;
   

    this.error = false;
    
    let index = 0;

    this.errorDna.forEach(item => {
      if(item != null  || this.formPerson.controls.dnas['controls'][index].value == null)
        this.error = true;
      
      index++;
    });



  }
}
