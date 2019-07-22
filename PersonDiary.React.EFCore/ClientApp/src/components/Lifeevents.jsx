import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { actionCreators } from '../store/Lifeevent.store';
import { PersonFullName } from '../components/PersonFullName';

class Persons extends Component {
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
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderLifeEventsTable(props) {
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Surname</th>
                </tr>
            </thead>
            <tbody>
                {props.persons.map(lifeevent =>
                    <tr key={lifeevent.id}>
                        <td><Link to={"/lifevent/" + lifeevent.id}><PersonFullName id="person.id"/> </Link></td>
                        <td><NavLink to={"/lifevent/" + lifeevent.id}>{lifeevent.eventdate}</NavLink></td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.startDateIndex || 0) - 5;
    const nextStartDateIndex = (props.startDateIndex || 0) + 5;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/lifevents/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/lifeevents/${nextStartDateIndex}`}>Next</Link>
        {props.persons.length == 0 ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.reducerPerson,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Persons);