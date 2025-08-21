import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ApplicantsPage from '../pages/ApplicantsPage';

export const AppRoutes = () => (
  <BrowserRouter>
    <Routes>
      <Route path="/applicants" element={<ApplicantsPage />} />
    </Routes>
  </BrowserRouter>
);
