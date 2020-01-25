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
import PrepopulateDatabaseView from './Views/PrepopulateDatabase/PrepopulateDatabaseView';
import SectionEdit from './Views/SectionIndex/SectionEdit';
import ScoredSections from './Views/SectionIndex/ScoredSections';
import MountainRanges from './Views/SectionIndex/MountainRanges';
import ProposedSections from './Views/SectionIndex/ProposedSections';
import EditTrip from './Views/UntraveledTrips/EditTrip';
import SectionAdd from './Views/SectionIndex/SectionAdd';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path={paths.PREPOPULATE_DATABASE} component={PrepopulateDatabaseView} />
        <Route exact path={paths.HOME_VIEW} component={HomeView} />
        <Route path={paths.SCORED_SECTIONS} component={ScoredSections} />
        <Route exact path={paths.MOUNTAIN_RANGES} component={MountainRanges} />
        <Route exact path={paths.PROPOSED_SECTIONS} component={ProposedSections} />
        <Route path={paths.SECTION_EDIT} component={SectionEdit} />
        <Route path={paths.SECTION_ADD} component={SectionAdd} />
        <Route exact path={paths.UNTRAVELED_TRIPS} component={UntraveledTripsView} />
        <Route path={paths.EDIT_TRIP} component={EditTrip} />
        <Route exact path={paths.UNVERIFIED_TRIPS} component={UnverifiedTripsView} />
        <Route exact path={paths.TRIP_VERIFICATION + paths.DATA} component={TripVerificationDataView} />
        <Route exact path={paths.TRIP_VERIFICATION + paths.PROOFS} component={TripVerificationProofsView} />
        <Route exact path={paths.TRIP_VERIFICATION + paths.DECISION} component={TripVerificationDecisionView} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
