import React from 'react';
import './App.css';
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import HomeView from './Views/Home/HomeView'

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={HomeView}/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
