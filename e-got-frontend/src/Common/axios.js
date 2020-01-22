import * as apiPaths from './apiPaths';

var axios = require('axios');

export default () => {
  return axios.create({baseURL: apiPaths.API_ADRESS})
}

