import logo from './logo.svg';
import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import ApplicationViews from './components/ApplicationViews';
import './App.css';

function App() {
  return (
    <Router>
      <ApplicationViews/>
    </Router>
  );
}

export default App;
