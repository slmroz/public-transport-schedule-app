import { appConfig } from '../config'

export const getSchedule = (stopId) => {
    return (dispatch, getState) => {
      // make async call to database

        const requestOptions = {
            method: 'GET',
            headers: { 'Accept': 'application/json' }
        };
    
        fetch(appConfig.serverUrl + `/api/schedule/` + stopId, requestOptions)
            .then(handleResponse)
            .then(
                routes => dispatch(success(routes)),
                error => dispatch(failure(error.toString()))
            );
    }

    function success(routes) { return { type: 'GET_SCHEDULE_SUCCESS', routes } }
    function failure(error) { return { type: 'GET_SCHEDULE_FAILURE' } }
  };


function handleResponse(response) {
    return response.text().then(text => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }

        return data;
    });
}