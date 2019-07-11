import { appConfig } from '../config'

import React from 'react';
import { connect } from 'react-redux';
import { getBusStopList } from '../Actions/BusStopActions'
import { getSchedule } from '../Actions/ScheduleActions'

class Schedule extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            stops: [],
            selectedStop: "",
            autoupdate: true
        }

        this.handleChange = this.handleChange.bind(this);
    }

    tick() {
        if(this.state.selectedStop){
            this.props.dispatch(getSchedule(this.state.selectedStop));
        }
    }

    componentDidMount() {
        this.props.dispatch(getBusStopList());
        this.startTimer();
    }

    componentWillUnmount(){
        this.stopTimer();
    }

    startTimer(){
        this.interval = setInterval(() => this.tick(), appConfig.autoupdateInterval * 1000);
    }

    stopTimer(){
        clearInterval(this.interval);
    }

    handleChange(event) {
        const {  name, value  } = event.target;

        if(name === "autoupdate"){
            this.setState({
                autoupdate: event.target.checked
            }, () => {
                this.state.autoupdate ? this.startTimer() : this.stopTimer();
            });
        }
        else {
            this.setState({
                selectedStop: value
            }, () => {
                this.tick();
            });
        }
    }

    render() {
        const { stops, routes } = this.props;
        return (
            <div className="container top">
                        <select className="custom-select " value={this.state.selectedSop} 
                            onChange={this.handleChange}>
                            <option key="" value="">Please select your preferred stop...</option>
                            {stops && stops.map((stop) => 
                                <option key={stop.Id} value={stop.Id}>{stop.Name}</option>)}
                        </select>
                { routes && 
                    <div className="card-deck mb-3 text-center departure-list">

                            { routes.map((route) =>
                                <div className="card" key={route.Route.Id}> 
                                    <div className="card-header">
                                        <h4 className="my-0 font-weight-normal">{route.Route.Name}</h4>
                                    </div>
                                    <div className="card-body">
                                            {
                                                    route.Departures.map((departure) => 
                                                    <div key={departure}>{ departure }</div>
                                                )
                                            }
                                    </div>
                                </div>
                                )
                            }
                    </div>
                }

                    <div className="custom-control custom-checkbox col-md timer-checkbox">
                                    <input type="checkbox" 
                                        className="custom-control-input" 
                                        id="autoupdate" 
                                        name="autoupdate"
                                        checked={this.state.autoupdate}
                                        onChange = {this.handleChange} />
                                    <label className="custom-control-label" htmlFor="autoupdate">Autoupdate</label>
                    </div>
                </div>

            
        );
    }
}

function mapStateToProps(state) {
    const { stops } = state.getBusStopList;
    const { routes } = state.getSchedule;
     return {
        stops,
        routes
    };
}

const connectedSchedule = connect(mapStateToProps)(Schedule);
export { connectedSchedule as Schedule };
