// src/components/Layout.tsx
import { Outlet, useLocation } from 'react-router-dom';
import Sidebar from './Sidebar';

export default function Layout() {
  const location = useLocation();
  const isLanding = location.pathname === '/';

  return (
    <div className="app-layout">
      {!isLanding && <Sidebar />}
      {/* <main style={{ marginLeft: !isLanding ? 220 : 0, padding: '2rem', width: '100%' }}> */}
      <main>
        <Outlet />
      </main>
    </div>
  );
}
