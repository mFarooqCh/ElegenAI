// src/components/Sidebar.tsx
import { FaEdit, FaBars, FaTimes } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import { useState, useEffect } from 'react';
import './Sidebar.css';

interface SidebarProps {
  isOpen?: boolean;
  setIsOpen?: (isOpen: boolean) => void;
}

export default function Sidebar({ isOpen: propIsOpen, setIsOpen: propSetIsOpen }: SidebarProps) {
  // Fallback to local state if props aren't provided
  const [localIsOpen, setLocalIsOpen] = useState(window.innerWidth > 768);
  
  // Use props if available, otherwise use local state
  const isOpen = propIsOpen !== undefined ? propIsOpen : localIsOpen;
  const setIsOpen = propSetIsOpen || setLocalIsOpen;
  const [isMobile, setIsMobile] = useState(window.innerWidth <= 768);

  useEffect(() => {
    // Initial check
    const checkMobile = () => {
      const mobile = window.innerWidth <= 768;
      setIsMobile(mobile);
    };
    
    checkMobile();
    
    // Add resize listener
    const handleResize = () => {
      checkMobile();
    };

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  // Close sidebar when clicking outside (for mobile)
  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      // Only handle this for mobile view
      if (isMobile && isOpen) {
        // Check if click is outside sidebar and not on toggle button
        const sidebar = document.querySelector('.sidebar');
        const toggle = document.querySelector('.sidebar-toggle');
        if (
          sidebar && 
          !sidebar.contains(event.target as Node) && 
          toggle && 
          !toggle.contains(event.target as Node)
        ) {
          setIsOpen(false);
        }
      }
    };

    document.addEventListener('mousedown', handleClickOutside);
    return () => document.removeEventListener('mousedown', handleClickOutside);
  }, [isMobile, isOpen, setIsOpen]);

  const toggleSidebar = (e: React.MouseEvent) => {
    if (e) e.stopPropagation(); // Prevent event bubbling
    setIsOpen(!isOpen);
  };

  return (
    <div className="sidebar-container">
      {/* Backdrop for mobile */}
      {isMobile && isOpen && (
        <div className="sidebar-backdrop" onClick={() => setIsOpen(false)}></div>
      )}
      
      <aside className={`sidebar ${isOpen ? 'open' : 'closed'}`}>
        <div className="logo">
          <Link to="/">
            <h1>EleganAI</h1>
          </Link>
        </div>
        <nav className="nav">
          <Link to="/app">
            <FaEdit /> 
            <span>CaptionGen</span>
          </Link>
          {/* Add more links here if needed */}
        </nav>
      </aside>
      
      {/* Single toggle button that moves with the sidebar */}
      <button className="sidebar-toggle" onClick={toggleSidebar}>
        {isOpen ? <FaTimes /> : <FaBars />}
      </button>
    </div>
  );
}
