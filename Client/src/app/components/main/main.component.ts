import { Component} from '@angular/core';
import { SongsService } from 'src/app/services/songs.service';



@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {

    public clicked: boolean = false; 
  constructor(private mySongService: SongsService) { }


    public HandleFileInput(event: any): void{
        this.clicked = true;
        let files = (event.target as HTMLInputElement).files;
        if(files){
            for(let index = 0; index < files.length; index++){
                if(files.item(index)){
                    this.addSong(files.item(index) as File);
                }
            }
        }
        (event.target as HTMLInputElement).files = null;
        (event.target as HTMLInputElement).value = "";
    }

    public addSong(file: File)
    {
        this.mySongService.addSong(file).subscribe(()=>{});
    }

    public loadTables(){
        this.mySongService.loadAllTables();
        this.clicked = false;
    }

    }


