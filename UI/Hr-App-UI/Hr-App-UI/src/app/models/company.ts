export interface Company {
    id: number;
    name: string;
    description: string;
    founded:number;
    image?: {
        id?: number,
        imageTitle?: string,
        imageData?: string
      }
}