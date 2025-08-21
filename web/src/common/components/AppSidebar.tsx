import React from 'react';
import { Menu } from 'antd';
import { UserOutlined } from '@ant-design/icons';

interface AppSidebarProps {
  collapsed: boolean;
}

const AppSidebar: React.FC<AppSidebarProps> = ({ collapsed }) => {
  return (
    <Menu
      theme="dark"
      mode="inline"
      defaultSelectedKeys={['/applicants']}
      inlineCollapsed={collapsed}
      items={[
        { key: '/applicants', icon: <UserOutlined />, label: 'Applicants' },
      ]}
    />
  );
};

export default AppSidebar;
