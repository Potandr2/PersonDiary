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
        this.state = {
            name: undefined, surname: undefined, lifeevents: undefined, fileList: [], uploading: false }
        this.onChange = this.onChange.bind(this);
        this.save = this.save.bind(this);
                    
        const id = parseInt(this.props.match.params.id, 10) || 0;
        this.props.requestPerson(id);
        this.id = id;

        this.uploadprops = {
            name: 'Biography',
            multiple: false,
            beforeUpload: file => {
                this.setState(state => ({
                    fileList: [...state.fileList, file],
                }));
                return false;
            }, 
            onChange(info) {
                
                if (info.file.status !== 'uploading') {
                    console.log(info.file, info.fileList);
                }
                if (info.file.status === 'done') {
                    message.success(`${info.file.name} file uploaded successfully`);
                } else if (info.file.status === 'error') {
                    message.error(`${info.file.name} file upload failed.`);
                }
            }
            
        };
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
    handleUpload = () => {
        const { fileList } = this.state;
        
        const formData = new FormData();
        fileList.forEach(file => {
            formData.append('files[]', file);
        });

        this.setState({
            uploading: true,
        });

        // You can use any AJAX library you like
        this.setState({
            fileList: [],
            uploading: false,
        });
    };
    

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
        const { uploading, fileList } = this.state;
        const props = {
            onRemove: file => {
                this.setState(state => {
                    const index = state.fileList.indexOf(file);
                    const newFileList = state.fileList.slice();
                    newFileList.splice(index, 1);
                    return {
                        fileList: newFileList,
                    };
                });
            },
            beforeUpload: file => {
                this.setState(state => ({
                    //fileList: [...state.fileList, file],
                    fileList: [file],
                }));
                return false;
            },
            fileList,
        };

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
                        <label>Biography file</label>
                        <div className="row">
                            <Upload {...props}>
                                <Button>
                                    <Icon type="upload" /> Select File
                                </Button>
                            </Upload>
                            <Button
                                type="primary"
                                onClick={this.handleUpload}
                                disabled={fileList.length === 0}
                                loading={uploading}
                                style={{ marginTop: 16 }}
                            >
                                {uploading ? 'Uploading' : 'Start Upload'}
                            </Button>
                            
                        </div>
                    </div>
                    <div className="form-group">
                        <input type="button" value="Save" onClick={this.save} className="btn btn-success" />
                        <input type="button" value="Delete" onClick={this.save} className="btn btn-danger" />
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