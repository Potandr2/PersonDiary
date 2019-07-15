import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Person.store';



class Person extends Component {
    displayName = Person.name

    constructor(props) {
        super(props);
        this.onChangePersonName = this.onChangePersonName.bind(this);
        this.onChangePersonSurName = this.onChangePersonSurName.bind(this);
        this.save = this.save.bind(this);

        const id = parseInt(this.props.match.params.id, 10) || 0;
        this.props.requestPerson(id);
    }

    onChangePersonName(e) {
        this.props.person.name = e.target.value;
        
    }
    onChangePersonSurName(e) {
        this.props.person.surname = e.target.value;
    }
    save(e) {
        this.props.savePerson(this.props.person);
    }
    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        var iii = nextProps;
    }


    static renderLifeEvents(lifeevents) {
        if (lifeevents)
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
            )
        else return "";
    }

    render() {

        if (this.props.person) {
            let contents = !this.props.person
                ? <p><em>Loading...</em></p>
                : Person.renderLifeEvents(this.props.person.lifeevents);

            return (
                <div>
                    <h1>Person</h1>
                    <p>This component demonstrates fetching data from the server.</p>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text" value={this.props.person.name} onChange={this.onChangePersonName} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label>Surname</label>
                        <input type="text" value={this.props.person.surname} onChange={this.onChangePersonSurName} className="form-control" />
                    </div>
                    <div className="form-group">
                        <input type="button" value="Сохранить" onClick={this.save} className="btn btn-success" />
                    </div>
                    {contents}
                </div>
            )
        }
        else return "loading...";
    }
}

export default connect(
    state => state.reducerPerson,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Person);