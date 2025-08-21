import {create} from 'zustand';
import type { Applicant } from '../../types/Applicant';
import * as api from '../../api/applicantsApi';

interface ApplicantState {
  applicants: Applicant[];
  loading: boolean;
  fetchApplicants: () => void;
}

export const useApplicantStore = create<ApplicantState>((set) => ({
  applicants: [],
  loading: false,
  fetchApplicants: async () => {
    set({ loading: true });
    const res = await api.getApplicants();
    set({ applicants: res.data, loading: false });
  },
}));