import React from 'react';
import { Button } from 'semantic-ui-react';
import * as apiPaths from '../../Common/apiPaths'

const axios = require('axios');

const axiosInstance = axios.create({
    baseURL: apiPaths.API_ADRESS
});

class PrepopulateDatabaseView extends React.Component {

    populateMountainSystems = () => {
        axiosInstance({
            method: 'post',
            url: apiPaths.POPULATE + apiPaths.MOUNTAIN_SYSTEM
        })
        .then(response => {
            console.log(response);
        })
        .catch(error => {
            console.log(error);
        })
    }

    populateMountainRanges = () => {
        axiosInstance({
            method: 'post',
            url: apiPaths.POPULATE + apiPaths.MOUNTAIN_RANGE
        })
        .then(response => {
            console.log(response);
        })
        .catch(error => {
            console.log(error);
        })
    }

    populateLocations = () => {
        axiosInstance({
            method: 'post',
            url: apiPaths.POPULATE + apiPaths.LOCATION
        })
        .then(response => {
            console.log(response);
        })
        .catch(error => {
            console.log(error);
        })
    }

    populateSections = () => {
        axiosInstance({
            method: 'post',
            url: apiPaths.POPULATE + apiPaths.SECTION
        })
        .then(response => {
            console.log(response);
        })
        .catch(error => {
            console.log(error);
        })
    }

    populateDatabase = () => {
        // this.populateMountainSystems();
        // this.populateMountainRanges();
        //this.populateLocations();
        this.populateSections();
    }

    render() {
        return(
            <div className="homeview--container">
                <Button onClick={this.populateDatabase}>
                    Załaduj przykładowe dane.
                </Button>
            </div>
        )
    }
}
export default PrepopulateDatabaseView;