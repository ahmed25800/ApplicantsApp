import React, { useEffect } from 'react';
import { Modal, Form, Input, InputNumber, Checkbox, message } from 'antd';
import type { Applicant } from '../../../types/Applicant';
import { useApplicantStore } from '../store';

interface Props {
  visible: boolean;
  onClose: () => void;
  editingApplicant?: Applicant;
}

const ApplicantForm: React.FC<Props> = ({ visible, onClose, editingApplicant }) => {
  const [form] = Form.useForm();
  const { createApplicant, updateApplicant } = useApplicantStore();
  useEffect(() => {
    if (editingApplicant) form.setFieldsValue(editingApplicant);
    else form.resetFields();
  }, [editingApplicant]);

  const handleOk = async () => {
    try {
      const values = await form.validateFields();
      if (editingApplicant) {
        await updateApplicant(editingApplicant.id!, values);
        message.success('Applicant updated!');
      } else {
        await createApplicant(values); 
        message.success('Applicant added!');
      }
      onClose();
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <Modal
      title={editingApplicant ? 'Edit Applicant' : 'Add Applicant'}
      visible={visible}
      onOk={handleOk}
      onCancel={onClose}
      okText="Save"
    >
      <Form form={form} layout="vertical">
        <Form.Item name="name" label="Name" rules={[{ required: true, min: 5 }]}>
          <Input />
        </Form.Item>
        <Form.Item name="familyName" label="Family Name" rules={[{ required: true, min: 5 }]}>
          <Input />
        </Form.Item>
        <Form.Item name="address" label="Address" rules={[{ required: true, min: 10 }]}>
          <Input />
        </Form.Item>
        <Form.Item name="countryOfOrigin" label="Country" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item
          name="emailAdress"
          label="Email"
          rules={[{ required: true, type: 'email' }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="age"
          label="Age"
          rules={[{ required: true, type: 'number', min: 20, max: 60 }]}
        >
          <InputNumber style={{ width: '100%' }} />
        </Form.Item>
        <Form.Item name="hired" valuePropName="checked">
          <Checkbox>Hired</Checkbox>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default ApplicantForm;