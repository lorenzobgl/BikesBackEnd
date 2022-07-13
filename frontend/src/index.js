import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Bikes from './components/pages/Bikes'
import Assistance from './components/pages/Assistance';
import Homepage from './components/pages/Homepage';


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
  <Routes>
      <Route path="/" element={<App />}>
        <Route path="/" element={<Homepage />}/>
        <Route path="Bikes" element={<Bikes />} />
        <Route path="Assistance" element={<Assistance/>} />
      </Route>
  </Routes>
  </BrowserRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
