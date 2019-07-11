import { appConfig } from '../config'

export const getBusStopList = () => {
    return (dispatch, getState) => {
      // make async call to database

        const requestOptions = {
            method: 'GET',
            headers: { 'Accept': 'application/json' }
        };
    
        fetch(appConfig.serverUrl + `/api/busstop`, requestOptions)
            .then(handleResponse)
            .then(
                stops => dispatch(success(stops)),
                error => dispatch(failure(error.toString()))
            );
    }

    function success(stops) { return { type: 'GET_BUS_STOP_LIST_SUCCESS', stops } }
    function failure(error) { return { type: 'GET_BUS_STOP_LIST_FAILURE' } }
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