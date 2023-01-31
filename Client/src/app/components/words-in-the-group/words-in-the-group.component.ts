import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WordVsGroupModel } from 'src/app/Models/wordVsGroup.model';
import { WordVsGroupService } from 'src/app/services/word-vs-group.service';
import * as XLSX from "xlsx";

@Component({
  selector: 'app-words-in-the-group',
  templateUrl: './words-in-the-group.component.html',
  styleUrls: ['./words-in-the-group.component.css']
})
export class WordsInTheGroupComponent implements OnInit {

    public groupId! : number;
    public listOfTheWordsInTheGroup! : WordVsGroupModel[]
    public groupName? : string;
  constructor(private myWordsVsGroupService: WordVsGroupService, private myActivatedRoute: ActivatedRoute) { }

  public async ngOnInit() {
    this.groupId = +this.myActivatedRoute.snapshot.params['groupId'];
    this.listOfTheWordsInTheGroup = await this.myWordsVsGroupService.getWordsVsGroupsByGroupID(this.groupId);
    if( this.listOfTheWordsInTheGroup[0] != null)
        this.groupName = this.listOfTheWordsInTheGroup[0].groupName;
    

        
  }

  public exportToExcel(){

    let element = document.getElementById("excel-table");
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb,ws, "sheet1");

    XLSX.writeFile(wb, this.groupName +".xlsx");
  }

}
