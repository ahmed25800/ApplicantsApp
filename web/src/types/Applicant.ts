export interface Applicant {
    id?: number;
    name: string;
    familyName: string;
    address: string;
    countryOfOrigin: string;
    emailAdress: string;
    age: number;
    hired?: boolean;
  }