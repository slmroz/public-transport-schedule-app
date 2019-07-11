export function getSchedule(state = {}, action) {
    switch (action.type) {
      case 'GET_SCHEDULE_SUCCESS':
        return { routes: action.routes } ;
      case 'GET_SCHEDULE_FAILURE':
        return state;
      default:
        return state
    }
  }
  
