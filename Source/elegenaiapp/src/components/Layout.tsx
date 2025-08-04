// src/components/Layout.tsx
import { Outlet, useLocation } from 'react-router-dom';
import Sidebar from './Sidebar';
import { useState, useEffect } from 'react';
import './Layout.css';

export default function Layout() {
  const location = useLocation();
  const isLanding = location.pathname === '/';
  const [isMobile, setIsMobile] = useState(window.innerWidth <= 768);
  const [sidebarOpen, setSidebarOpen] = useState(!isMobile);

  useEffect(() => {
    const handleResize = () => {
      const mobile = window.innerWidth <= 768;
      setIsMobile(mobile);
      // Auto close sidebar on mobile
      if (mobile) {
        setSidebarOpen(false);
      } else {
        setSidebarOpen(true);
      }
    };

    // Initial check
    handleResize();

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  // Close sidebar when clicking on main content (mobile only)
  const handleMainClick = (e: React.MouseEvent) => {
    if (isMobile && sidebarOpen) {
      setSidebarOpen(false);
    }
  };

  return (
    <div className="app-layout">
      {!isLanding && <Sidebar isOpen={sidebarOpen} setIsOpen={setSidebarOpen} />}
      <main 
        className={isMobile ? 'mobile-main' : 'desktop-main'}
        onClick={handleMainClick}
      >
        <Outlet />
      </main>
    </div>
  );
}
