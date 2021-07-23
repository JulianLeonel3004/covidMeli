import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalGeneralComponent } from 'src/app/shared/components/modal-general/modal-general.component';


@Component({
  selector: 'app-hola-mundo',
  templateUrl: './hola-mundo.component.html',
  styleUrls: ['./hola-mundo.component.scss']
})
export class HolaMundoComponent implements OnInit {

  constructor(private modalService:NgbModal) { }

  ngOnInit() {
  }


  openModal(){
    const modalRef = this.modalService.open(ModalGeneralComponent, { backdrop: true });
    modalRef.componentInstance.title = "Hola!";
    modalRef.componentInstance.message = "Hola Mundo";
    modalRef.componentInstance.actionModal = ()=>{
      console.log("Hola Mundo Modal!!");
    };
  }
  
}
