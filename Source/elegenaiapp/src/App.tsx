// App.tsx
import { Routes, Route } from 'react-router-dom';
import LandingPage from './pages/LandingPage';
import AppPage from './pages/AppPage';
import Layout from './components/Layout';

function App() {
  return (
      <Routes>
        {/* No layout */}
        <Route path="/" element={<LandingPage />} />

        {/* Layout wraps the /app routes */}
        <Route element={<Layout />}>
          <Route path="/app" element={<AppPage />} />
          {/* Add more nested routes here if needed */}
        </Route>
      </Routes>
  );
}

export default App;
