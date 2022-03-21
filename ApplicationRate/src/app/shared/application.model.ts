export class Application {
    id:number;
    name:string;
    effectiveDate:string;
    addressStreet:string;
    addressCity:string;
    addressState:string;
    addressZip:string;
    insuredValueAmount:number;

    constructor(){
        this.id = 0;
        this.name = '';
        this.effectiveDate = '';
        this.addressStreet = '';
        this.addressCity = '';
        this.addressState = '';
        this.addressZip = '';
        this.insuredValueAmount = 0;
    }

}
