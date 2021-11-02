export interface Employee {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    image?: {
        id: number,
        imageTitle: string,
        imageData: string
      }
}
