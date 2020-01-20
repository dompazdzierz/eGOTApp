import React from 'react';
import './App.css';
import * as paths from './Common/paths'
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import HomeView from './Views/Home/HomeView'
import UntraveledTripsView from './Views/UntraveledTrips/UntraveledTripsView';
import TripVerificationDataView from './Views/TripVerification/TripVerificationData/TripVerificationDataView';
import TripVerificationProofsView from './Views/TripVerification/TripVerificationProofs/TripVerificationProofsView';
import TripVerificationDecisionView from './Views/TripVerification/TripVerificationDecision/TripVerificationDecisionView';
import UnverifiedTripsView from './Views/TripVerification/UnverifiedTripsView/UnverifiedTripsView';
import MountainRange from './Views/SectionList/MountainRange';
import ProposedSections from './Views/SectionList/ProposedSections';
import MountainSystems from './Views/SectionList/MountainSystems';
import PrepopulateDatabaseView from './Views/PrepopulateDatabase/PrepopulateDatabaseView';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path={paths.PREPOPULATE_DATABASE} component={PrepopulateDatabaseView} />

        <Route exact path={paths.HOME_VIEW} component={HomeView} />
        <Route exact path={paths.SECTION_LIST} component={MountainRange} />
        <Route exact path={paths.UNTRAVELED_TRIPS} component={UntraveledTripsView} />
        <Route exact path={paths.UNVERIFIED_TRIPS} component={UnverifiedTripsView} />
        <Route exact path={paths.PROPOSED_SECTIONS} component={ProposedSections} />
        <Route exact path={paths.MOUNTAIN_SYSTEMS} component={MountainSystems} />
        <Route exact path={paths.TRIP_VERIFICATION + paths.DATA} component={TripVerificationDataView} />
        <Route exact path={paths.TRIP_VERIFICATION + paths.PROOFS} component={TripVerificationProofsView} />
        <Route exact path={paths.TRIP_VERIFICATION + paths.DECISION} component={TripVerificationDecisionView} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
