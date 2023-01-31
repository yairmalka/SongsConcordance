export class SongModel{

    public constructor(
        public songId?  : number,
        public artist?  : string,
        public title?   : string,
        public year?    : number,
        public album?   : string,
        public genre?   : string,
        public filePath?: string ){
    }
    
    }
