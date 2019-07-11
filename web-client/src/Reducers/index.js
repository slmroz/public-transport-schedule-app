import { combineReducers } from 'redux';

import { getBusStopList } from './BusStopReducer';
import { getSchedule } from './ScheduleReducer';

const rootReducer = combineReducers({
    getBusStopList,
    getSchedule
});

export default rootReducer;