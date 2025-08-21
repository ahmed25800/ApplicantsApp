import { create } from 'zustand';
import type { Applicant } from '../../types/Applicant';
import * as api from '../../api/applicantsApi';

interface ApplicantState {
  applicants: Applicant[];
  loading: boolean;
  fetchApplicants: () => Promise<void>;
  createApplicant: (data: Applicant) => Promise<void>;
  updateApplicant: (id: number, data: Applicant) => Promise<void>;
  deleteApplicant: (id: number) => Promise<void>;
}

const useApplicantStore = create<ApplicantState>((set) => ({
  applicants: [],
  loading: false,

  fetchApplicants: async () => {
    set({ loading: true });
    try {
        debugger;
      const data = (await api.getApplicants()).data || [];
      set({ applicants: data, loading: false });
    } catch (error) {
      console.error('Failed to fetch applicants:', error);
      set({ loading: false });
      throw error;
    }
  },

  createApplicant: async (data: Applicant) => {
    set({ loading: true });
    try {
      const res = (await api.createApplicant(data))?.data?.data;
      if (res) {
        set((state) => ({
            applicants: [...state.applicants, res],
            loading: false,
          }));      
        }else{
            set({ loading: false });

        }

      
    } catch (error) {
      console.error('Failed to create applicant:', error);
      set({ loading: false });
      throw error;
    }
  },

  updateApplicant: async (id: number, data: Applicant) => {
    set({ loading: true });
    try {
      const res = (await api.updateApplicant(id, data))?.data?.data;
      if (res){
        set((state) => ({
            applicants: state.applicants.map((applicant) =>
              applicant.id === id ? res : applicant
            ),
            loading: false,
          }));
      }else{
        set({ loading: false });
      }
      
    } catch (error) {
      console.error('Failed to update applicant:', error);
      set({ loading: false });
      throw error;
    }
  },

  deleteApplicant: async (id: number) => {
    set({ loading: true });
    try {
      await api.deleteApplicant(id);
      set((state) => ({
        applicants: state.applicants.filter((applicant) => applicant.id !== id),
        loading: false,
      }));
    } catch (error) {
      console.error('Failed to delete applicant:', error);
      set({ loading: false });
      throw error;
    }
  },
}));

export default useApplicantStore;