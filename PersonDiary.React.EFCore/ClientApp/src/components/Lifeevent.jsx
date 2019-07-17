import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Lifeevent.store';
import { DatePicker } from 'antd';
import moment from 'moment';


const { MonthPicker, RangePicker } = DatePicker;
const dateFormat = 'YYYY/MM/DD';
const monthFormat = 'YYYY/MM';
const dateFormatList = ['DD/MM/YYYY', 'DD/MM/YY'];

class Lifeevent extends Component {
    displayName = Lifeevent.name   

    constructor(props) {
        super(props);
        this.state = { name: undefined, eventdate: undefined}
        this.onChange = this.onChange.bind(this);
        this.onChangeDate = this.onChangeDate.bind(this);
        this.save = this.save.bind(this);

        const id = parseInt(this.props.match.params.id, 10) || 0;
        this.props.requestLifeEvent(id);
        this.id = id;
        this.PersonId = undefined;
    }

    onChange(e) {
        var fieldname = e.target.name;
        var newstate = {};
        newstate[fieldname] = e.target.value;
        this.setState(newstate);
    }
    onChangeDate(date, dateString) {
        this.setState({ eventdate: dateString });
    }
    save(e) {
        var lifeevent = { id: this.id, name: this.state.name, eventdate: this.state.eventdate };
        lifeevent.personId = this.personId;
        this.props.saveLifeEvent(lifeevent);
    }
    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        if (nextProps.lifeevent && nextProps.lifeevent.id == this.id) {
            this.setState({
                name: nextProps.lifeevent.name,
                eventdate: nextProps.lifeevent.eventdate
            });
            this.personId = nextProps.lifeevent.personId;
        }
    }

    render() {

        if (this.state.name) {
            return (
                <div>
                    <h1>LifeEvent</h1>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text" name="name" value={this.state.name} onChange={this.onChange} className="form-control" />
                    </div>
                    <div className="form-group">
                        <label>Date</label>
                        <DatePicker defaultValue={moment(this.state.eventdate, dateFormat)} format={dateFormat} onChange={this.onChangeDate} />
                    </div>
                    <div className="form-group">
                        <input type="button" value="Сохранить" onClick={this.save} className="btn btn-success" />
                    </div>
                   
                </div>
            )
        }
        else return "loading...";
    }
}

export default connect(
    state => state.reducerLifeEvent,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Lifeevent);