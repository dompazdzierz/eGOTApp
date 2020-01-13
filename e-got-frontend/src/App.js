import React from 'react';
import './App.css';
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import HomeView from './Views/Home/HomeView'
import UntraveledTripsView from './Views/UntraveledTrips/UntraveledTripsView';
import TripVerificationDataView from './Views/TripVerification/TripVerificationData/TripVerificationDataView';
import TripVerificationProofsView from './Views/TripVerification/TripVerificationProofs/TripVerificationProofsView';
import * as paths from './Constants/paths'

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path={paths.HOME_VIEW} component={HomeView}/>
        <Route exact path={paths.UNTRAVELED_TRIPS} component={UntraveledTripsView}/>
        <Route exact path={paths.TRIP_VERIFICATION + paths.DATA} component={TripVerificationDataView}/>
        <Route exact path={paths.TRIP_VERIFICATION + paths.PROOFS} component={TripVerificationProofsView}/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
