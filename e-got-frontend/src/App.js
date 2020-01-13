import React from 'react';
import './App.css';
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import HomeView from './Views/Home/HomeView'
import UntraveledTripsView from './Views/UntraveledTrips/UntraveledTripsView';
import TripVerificationDataView from './Views/TripVerification/TripVerificationData/TripVerificationDataView';
import * as paths from './Constants/paths'

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path={paths.homeView} component={HomeView}/>
        <Route exact path={paths.untraveledTrips} component={UntraveledTripsView}/>
        <Route exact path={paths.tripVerification + paths.data} component={TripVerificationDataView}/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
