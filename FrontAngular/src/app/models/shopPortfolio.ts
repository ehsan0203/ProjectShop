export class ShopPortfolio {
    id:string|null;
    fileName: string|null;
    fileTitle: string|null;
    filePath: string|null;
    constructor(id:string|null=null,fileName: string|null=null,fileTitle: string|null,filePath: string|null){
        this.id=id;
        this.fileName=fileName;
        this.filePath=filePath;
        this.fileTitle=fileTitle;
    }
}
