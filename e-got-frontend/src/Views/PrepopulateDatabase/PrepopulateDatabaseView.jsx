import React from 'react';
import { Button } from 'semantic-ui-react';
import * as apiPaths from '../../Common/apiPaths'

const axios = require('axios');

const axiosInstance = axios.create({
    baseURL: apiPaths.API_ADRESS
});

class PrepopulateDatabaseView extends React.Component {

    populateAll = () => {
        axiosInstance({
            method: 'post',
            url: apiPaths.POPULATE_ALL
        })
        .then(response => {
            console.log(response);
        })
        .catch(error => {
            console.log(error);
        })
    }

    populateDatabase = () => {
        this.populateAll();
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