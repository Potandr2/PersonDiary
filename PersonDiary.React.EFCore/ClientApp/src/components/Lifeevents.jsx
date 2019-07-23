import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { actionCreators } from '../store/Lifeevent.store';


class LifeEvents extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
        this.props.requestLifeEvents(startDateIndex);
    }

    render() {
        return (
            
            <div>
                <h1>Event list</h1>
                {renderLifeEventsTable(this.props)}
               
            </div >

        );
    }
}

function renderLifeEventsTable(props) {
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>Person</th>
                    <th>Event</th>
                    <th>Date</th>
                </tr>
            </thead>
            <tbody>
                {props.lifeevents.map(lifeevent =>
                    <tr key={lifeevent.id}>
                        <td><NavLink to={"/lifevent/" + lifeevent.id}>{lifeevent.personfullname}</NavLink></td>
                        <td><NavLink to={"/lifevent/" + lifeevent.id}>{lifeevent.name}</NavLink></td>
                        <td><NavLink to={"/lifevent/" + lifeevent.id}>{lifeevent.eventdate}</NavLink></td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}



export default connect(
    state => state.reducerLifeEvent,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(LifeEvents);