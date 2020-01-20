import React from 'react';
import { Button } from 'semantic-ui-react';
import * as apiPaths from '../../Common/apiPaths'
import { MOUNTAIN_RANGES_JSON, MOUNTAIN_SYSTEMS_JSON } from '../../Common/values'

const axios = require('axios');

const axiosInstance = axios.create({
    baseURL: apiPaths.API_ADRESS
});

class PrepopulateDatabaseView extends React.Component {

    populateMountainSystems = () => {
        axiosInstance({
            method: 'post',
            url: apiPaths.MOUNTAIN_SYSTEM + apiPaths.ADD_ELEMENTS,
            data: MOUNTAIN_SYSTEMS_JSON
        })
        .then(response => {
            console.log(response);
        })
        .catch(response => {
            console.log(response);
        })
    }

    populateMountainRanges = () => {
        console.log('Start');

        axiosInstance({
            method: 'post',
            url: apiPaths.MOUNTAIN_RANGE + apiPaths.ADD_ELEMENTS,
            data: MOUNTAIN_RANGES_JSON
        })
        .then(response => {
            console.log(response);
        })
        .catch(response => {
            console.log(response);
        })
    }

    render() {
        return(
            <div className="homeview--container">
                <Button onClick={this.populateMountainSystems}>
                    Załaduj systemy.
                </Button>
                <Button onClick={this.populateMountainRanges}>
                    Załaduj range.
                </Button>
            </div>
        )
    }
}
export default PrepopulateDatabaseView;