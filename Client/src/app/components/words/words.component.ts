import { Component, OnInit } from '@angular/core';
import { WordModel } from 'src/app/Models/word.model';
import { WordsService } from 'src/app/services/words.service';



@Component({
  selector: 'app-words',
  templateUrl: './words.component.html',
  styleUrls: ['./words.component.css']
})
export class WordsComponent implements OnInit {

    public words! : WordModel[];

  constructor(private myWordsService: WordsService) { }

  async ngOnInit() {

    try{
        this.words = await this.myWordsService.getAllWords();
    }

    catch(error){
        alert(error)
    }

  }

}
