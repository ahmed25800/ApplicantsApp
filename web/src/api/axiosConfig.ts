import axios from 'axios';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5000/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.headers['content-type']?.includes('application/problem+json')) {
      return Promise.reject(error.response.data);
    }
    return Promise.reject(error);
  }
);

export default api;
