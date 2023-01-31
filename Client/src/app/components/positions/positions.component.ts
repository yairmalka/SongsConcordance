import { Component, OnInit } from '@angular/core';
import { PositionModel } from 'src/app/Models/position.model';
import { PositionsService } from 'src/app/services/positions.service';

@Component({
  selector: 'app-positions',
  templateUrl: './positions.component.html',
  styleUrls: ['./positions.component.css']
})
export class PositionsComponent implements OnInit {

    public positions! : PositionModel[];


    constructor(private myPositionService: PositionsService){}

 async ngOnInit() {

    try{
        this.positions = await this.myPositionService.getAllWordsPositions();
    }

    catch(error){
        alert(error);
    }


  }

}
