export function getBusStopList(state = {}, action) {
    switch (action.type) {
      case 'GET_BUS_STOP_LIST_SUCCESS':
        return { stops: action.stops } ;
      case 'GET_BUS_STOP_LIST_FAILURE':
        return state;
      default:
        return state
    }
  }
  
