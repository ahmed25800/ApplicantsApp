import React, { useState } from 'react';
import { Layout, Button, theme } from 'antd';
import { MenuFoldOutlined, MenuUnfoldOutlined } from '@ant-design/icons';
import AppSidebar from './common/components/AppSidebar';
import { AppRoutes } from './routes/AppRoutes';
import ErrorHandler from './common/components/ErrorHandler';

const { Header, Sider, Content } = Layout;

const App: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  return (
    <Layout style={{ minHeight: '100vh' }}>
      <ErrorHandler />
      <Sider trigger={null} collapsible collapsed={collapsed}>
        <div className="logo" 
        style={{ height: 32, margin: 16, padding:5, background: 'rgba(226, 226, 226, 0.3)' }} >
          logo sample
          </div>
        <AppSidebar collapsed={collapsed} />
      </Sider>

      <Layout>
        <Header style={{ padding: 0, background: colorBgContainer }}>
          <Button
            type="text"
            icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
            onClick={() => setCollapsed(!collapsed)}
            style={{ fontSize: '16px', width: 64, height: 64 }}
          />
        </Header>

        <Content
          style={{
            margin: '15px 10px',
            padding: 20,
            minHeight: 280,
            background: colorBgContainer,
            borderRadius: borderRadiusLG,
          }}
        >
          <AppRoutes />
        </Content>
      </Layout>
    </Layout>
  );
};

export default App;
