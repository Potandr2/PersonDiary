import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Person.store';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { Upload, message, Button, Icon } from 'antd';




class Person extends Component {
    displayName = Person.name
    

    constructor(props) {
        super(props);
        this.state = { name: undefined, surname: undefined, lifeevents: undefined }
        this.onChange = this.onChange.bind(this);
        this.save = this.save.bind(this);
            
        const id = parseInt(this.props.match.params.id, 10) || 0;
        this.props.requestPerson(id);
        this.id = id;

        this.uploadprops = {
            name: 'Biography',
            data: JSON.stringify({ json: { PersonId: 111 } }),
            multiple: false,
            action: 'http://localhost:44396/api/personfile/',
            onChange(info) {
                if (info.file.status !== 'uploading') {
                    console.log(info.file, info.fileList);
                }
                if (info.file.status === 'done') {
                    message.success(`${info.file.name} file uploaded successfully`);
                } else if (info.file.status === 'error') {
                    message.error(`${info.file.name} file upload failed.`);
                }
            },
        };
    }

    onChange(e) {
        var fieldname = e.target.name;
        var newstate = {};
        newstate[fieldname] = e.target.value;
        this.setState(newstate);
    }
    
    save(e) {
        var person = {id:this.id, name: this.state.name, surname: this.state.surname };
        this.props.savePerson(person);
    }
    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        if (nextProps.person && nextProps.person.id == this.id) {
            this.setState({
                name: nextProps.person.name,
                surname: nextProps.person.surname,
                lifeevents: nextProps.person.lifeEvents
            });
        }
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
                                <td><Link to={"/lifeevent/" + lifeevent.id}>{lifeevent.name}</Link></td>
                                <td><Link to={"/lifeevent/" + lifeevent.id}>{lifeevent.eventdate}</Link></td>
                                
                            </tr>
                        )}
                    </tbody>
                </table>
            )
        else return "";
    }

    render() {

        if (this.state.lifeevents) {
            let contents = Person.renderLifeEvents(this.state.lifeevents);

            return (
                <div>
                    <h1>Person</h1>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text" name="name" value={this.state.name} onChange={this.onChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label>Surname</label>
                        <input type="text" name="surname" value={this.state.surname} onChange={this.onChange} className="form-control" />
                    </div>
                    <div className="form-group">
                    <Upload {...this.uploadprops}>
                        <Button>
                            <Icon type="upload" /> Click to Upload
                        </Button>
                        </Upload>
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