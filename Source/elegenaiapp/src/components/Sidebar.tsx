// src/components/Sidebar.tsx
import { FaEdit } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import './Sidebar.css';

export default function Sidebar() {
  return (
    <aside className="sidebar">
      <div className="logo">
        <Link to="/">
          <h1>EleganAI</h1>
        </Link>
      </div>
      <nav className="nav">
        <Link to="/captiongen">
          <FaEdit /> 
          {/* <span>CaptionGen</span> */}
        </Link>
        {/* Add more links here if needed */}
      </nav>
    </aside>
  );
}
