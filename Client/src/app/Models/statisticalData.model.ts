 export class StatisticalDataModel{
  
    constructor(public longestWord: string,
                public shortestWord: string,
                public wordsAvgLength: number,
                public howMuchWordsInTheSong: number,
                public wordsAppearsTheMostInTheSong: string[],
                public howMuchWordsInVerses: string[],
                public howMuchWordsInSentences: string[]
            )
            {}  
 }
