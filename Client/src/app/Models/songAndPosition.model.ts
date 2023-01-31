export class SongAndPositionModel{

    constructor(public songId?:number,
         public positionId?: number, 
         public artist?: string, 
         public title?: string, 
         public wordValue?: string,
         public artistAndTitle?: string,
         public wordIndex?: number,
         public sentenceNumber?: number,
         public verseNumber?: number ){}

}
