import { Generic } from "./generic";
export class Person extends Generic{
  country:string;
  dna:Array<string>;
  result:string;

  constructor(item:any){
    super(item.id, item.name);
    this.country = item.country;
    this.dna = item.dnas;
    this.result = item.result;
  }
}
