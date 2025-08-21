import { create } from 'zustand';
import type { ProblemDetails } from '../../types/common/ProblemDetails';

interface ErrorState {
  error: ProblemDetails | null;
  setError: (error: ProblemDetails | null) => void;
}

 const useErrorStore = create<ErrorState>((set) => ({
  error: null,
  setError: (error) => set({ error }),
}));

export default useErrorStore;