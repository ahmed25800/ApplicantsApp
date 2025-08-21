export interface ProblemDetails {
    type?: string;
    title?: string;
    status?: number;
    detail?: string;
    instance?: string;
    errors?:ValidationErrors
  };


interface ValidationErrors {
[field: string]: string[]; 
}