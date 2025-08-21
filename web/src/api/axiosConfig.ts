import axios from 'axios';
import { AxiosError } from 'axios';
import userErrorStore from '../common/stores/ErrorStore';

import type { ProblemDetails } from '../types/common/ProblemDetails';
const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5000/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.response.use(
    (response) => {
        
      return response;
    },
    (error: AxiosError) => {
      if (error.response?.data) {
        const problem: ProblemDetails = error.response.data;
        userErrorStore.getState().setError(problem);
        return Promise.reject(problem);
      }
      return Promise.reject({
        title: 'Network Error',
        detail: error.message,
        status: 0,
      } as ProblemDetails);
    }
  );
  

export default api;
