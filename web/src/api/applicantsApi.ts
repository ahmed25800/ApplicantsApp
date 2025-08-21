import api from './axiosConfig';
import type { Applicant } from '../types/Applicant';
import type { BaseResponse } from '../types/common/BaseResponse';

const ENDPOINT = '/applicants'; 
export const getApplicants = async () => {
  return (await api.get<Applicant[]>(ENDPOINT));
};

export const createApplicant = async (data: Applicant) => {
  return await api.post<BaseResponse<Applicant>>(ENDPOINT, data);
};

export const updateApplicant = async (id: number, data: Applicant) => {
  return await api.put<BaseResponse<Applicant>>(`${ENDPOINT}/${id}`, data);
};

export const deleteApplicant = async (id: number) => {
  return await api.delete<BaseResponse<Applicant>>(`${ENDPOINT}/${id}`);
};