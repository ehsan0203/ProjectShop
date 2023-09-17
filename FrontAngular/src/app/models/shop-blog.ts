export class ShopBlog {
    id:string|null;
    fileName: string|null;
    title: string|null;
    fileDescription:string|null;
    filePath: string|null;
    

    constructor(id:string|null=null,fileName: string|null=null,title: string|null,filePath: string|null,fileDescription:string|null){
        this.id=id;
        this.fileName=fileName;
        this.filePath=filePath;
        this.title=title;
        this.fileDescription=fileDescription
    }
}
