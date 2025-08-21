import React, { useState } from 'react';
import { Table, Button, Popconfirm } from 'antd';
import type { Applicant } from '../../../types/Applicant';
import ApplicantForm from './ApplicantForm';
import useApplicantStore  from '../store';

interface Props {
  applicants: Applicant[];
}

const ApplicantTable: React.FC<Props> = ({ applicants  }) => {
  const { deleteApplicant } = useApplicantStore();
  const [editingApplicant, setEditingApplicant] = useState<Applicant | undefined>();
  const [modalVisible, setModalVisible] = useState(false);

  const openEdit = (applicant: Applicant) => {
    setEditingApplicant(applicant);
    setModalVisible(true);
  };

  const columns = [
    { title: 'Name', dataIndex: 'name', key: 'name' },
    { title: 'Family Name', dataIndex: 'familyName', key: 'familyName' },
    { title: 'Address', dataIndex: 'address', key: 'address' },
    { title: 'Country', dataIndex: 'countryOfOrigin', key: 'countryOfOrigin' },
    { title: 'Email', dataIndex: 'emailAdress', key: 'emailAdress' },
    { title: 'Age', dataIndex: 'age', key: 'age' },
    { title: 'Hired', dataIndex: 'hired', key: 'hired', render: (h: boolean) => (h ? 'Yes' : 'No') },
    {
      title: '',
      key: 'actions',
      render: (_: any, record: Applicant) => (
        <>
          <Button type="link" onClick={() => openEdit(record)}>Edit</Button>
          <Popconfirm
            title="Are you sure?"
            onConfirm={() => deleteApplicant(record.id!)}
          >
            <Button type="link" danger>Delete</Button>
          </Popconfirm>
        </>
      ),
    },
  ];

  return (
    <>
      <Button
        type="primary"
        style={{ marginBottom: 16 }}
        onClick={() => { setEditingApplicant(undefined); setModalVisible(true); }}
      >
        Add Applicant
      </Button>
      <Table dataSource={applicants} columns={columns} rowKey="id" />
      {modalVisible && (
        <ApplicantForm
          visible={modalVisible}
          onClose={() => setModalVisible(false)}
          editingApplicant={editingApplicant}
        />
      )}
    </>
  );
};

export default ApplicantTable;
