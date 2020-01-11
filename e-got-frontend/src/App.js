import React from 'react';
import './App.css';
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import HomeView from './Views/Home/HomeView'
import UncompletedTripsView from './Views/UncompletedTrips/UncompletedTripsView';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={HomeView}/>
        <Route exact path="/uncompleted-trips/" component={UncompletedTripsView}/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
