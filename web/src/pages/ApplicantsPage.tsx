import React, { useEffect } from 'react';
import  useApplicantStore  from '../features/applicants/store';
import ApplicantTable from '../features/applicants/components/ApplicantTable';
import { Spin } from 'antd';

const ApplicantsPage: React.FC = () => {
  const { applicants, loading, fetchApplicants } = useApplicantStore();


  useEffect(() => {
    fetchApplicants();
    console.log(applicants)
  }, []);

  

  if (loading) return <Spin size="large" />;

  return (
    <div >
      <h2>Applicants</h2>
      
      
      <ApplicantTable applicants={applicants}  />
    </div>
  );
};

export default ApplicantsPage;