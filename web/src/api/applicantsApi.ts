import api from './axiosConfig';
import type { Applicant } from '../types/Applicant';

const API_URL = '/applicants'; 
export const getApplicants = async () => {
  return api.get<Applicant[]>(API_URL);
};

export const createApplicant = async (data: Applicant) => {
  return api.post<Applicant>(API_URL, data);
};

export const updateApplicant = async (id: number, data: Applicant) => {
  return api.put<Applicant>(`${API_URL}/${id}`, data);
};

export const deleteApplicant = async (id: number) => {
  return api.delete(`${API_URL}/${id}`);
};