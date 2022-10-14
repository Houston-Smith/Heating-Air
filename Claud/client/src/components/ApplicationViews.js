import React from "react";
import { Routes, Route, Navigate, Outlet } from "react-router-dom";
import { Home } from "./Home";

export default function ApplicationViews({ isLoggedIn }) {
  
  return (
    <main>
      <Routes>
        <Route path="/" element={<Home/>}/>
      </Routes>
    </main>
  );
}