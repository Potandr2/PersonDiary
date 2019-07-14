import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Person.store';



class Person extends Component {
    displayName = Person.name

    constructor(props) {
        super(props);
        this.onChangePersonName = this.onChangePersonName.bind(this);
        this.save = this.save.bind(this);

        const id = parseInt(this.props.match.params.id, 10) || 0;
        this.props.requestPerson(id);
    }

    onChangePersonName(e) {
        this.props.person.name = e.target.value;
    }
    save(e) {
        this.props.savePerson(this.props.person);
        /*
        fetch('api/upload/' + this.state.id, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.state.upload)
        })//.then(response => (response) ? response.json() : "" )
            .then(data => {
                alert('saved');//this.setState({ forecasts: data, loading: false });
            });
            */
        alert('22');
    }
    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        var iii = nextProps;
    }


    static renderLifeEvents(lifeevents) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    {lifeevents.map(lifeevent =>
                        <tr key={lifeevent.id}>
                            <td>{lifeevent.name}</td>
                            <td>{lifeevent.eventdate}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {

        let i = 0;
        let contents = !this.props.lifeevent
            ? <p><em>Loading...</em></p>
            : Person.renderLifeEvent(this.props.person.lifeevents);

        let Name = this.props.person ? this.props.person.name : "";
        let Surname = this.props.person ? this.props.person.surname : "";
        return (
            <div>
                <h1>Person</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <div className="form-group">
                    <label>Name</label>
                    <input type="text" value={Name} onChange={this.onChangePersonName} className="form-control" />
                </div>
                <div className="form-group">
                    <label>Surname</label>
                    <input type="text" value={Surname} className="form-control" />
                </div>
                <div className="form-group">
                    <input type="button" value="Сохранить" onClick={this.save} className="btn btn-success" />
                </div>
                {contents}
            </div>
        );
    }
}

export default connect(
    state => state.reducerPerson,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Person);