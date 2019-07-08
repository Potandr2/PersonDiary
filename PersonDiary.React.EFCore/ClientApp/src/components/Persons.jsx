import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { actionCreators } from '../store/Person.store';

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
        this.props.requestPersons(startDateIndex);
    }

    render() {
        return (
            <div>
                <h1>Person list</h1>
                {renderPersonsTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderPersonsTable(props) {
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
                {props.persons.map(person =>
                    <tr key={person.id}>
                        <td><Link to={"/person/" + person.id}>{person.id}</Link></td>
                        <td><NavLink to={"/person/" + person.id}>{person.name}</NavLink></td>
                        <td><NavLink to={"/person/" + person.id}>{ person.surname }</NavLink></td>
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
        <Link className='btn btn-default pull-left' to={`/persons/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/persons/${nextStartDateIndex}`}>Next</Link>
        {props.persons.length==0 ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.reducerPerson,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Persons);