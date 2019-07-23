import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Person.store';

class PersonFullName extends Component {
    displayName = PersonFullName.name

    constructor(props) {
        super(props);

        const id = parseInt(this.props.id, 10) || 0;
        this.props.requestPerson(id);
        this.id = id;

        this.state = {
            id: this.id,
            fullname: undefined
        }
    }
    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        if (nextProps.person && nextProps.person.id == this.id) {
            this.setState({
                fullname: `${nextProps.person.surname} ${nextProps.person.name}`,
            });
        }
    }
    render() {
        return <Link to={`/person/${this.id}`}>{this.state.fullname}</Link>;
    }
}

export default connect(
    state => state.reducerPerson,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PersonFullName);