import React, { useEffect } from 'react';
import { useApplicantStore } from '../features/applicants/store';
import ApplicantTable from '../features/applicants/components/ApplicantTable';
// import ApplicantForm from '../features/applicants/components/ApplicantForm';
import { Spin } from 'antd';

const ApplicantsPage: React.FC = () => {
  const { applicants, loading, fetchApplicants } = useApplicantStore();

  useEffect(() => {
    fetchApplicants();
  }, []);

  if (loading) return <Spin size="large" />;

  return (
    <div style={{ padding: 20 }}>
      <h1>Applicants</h1>
      {/* <ApplicantForm visible={true} /> */}
      <ApplicantTable applicants={applicants} />
    </div>
  );
};

export default ApplicantsPage;
