const requestPersonsType = 'REQUEST_PERSONS';
const receivePersonsType = 'RECEIVE_PERSONS';
const requestPersonType = 'REQUEST_PERSON';
const receivePersonType = 'RECEIVE_PERSON';
const savePersonType = 'SAVE_PERSON';
const initialState = { persons: [], person: undefined, isLoading: false };

export const actionCreators = {
    requestPersons: startDateIndex => async (dispatch) => {

        dispatch({ type: requestPersonsType, startDateIndex });

        const url = 'api/person/';
        const response = await fetch(url);
        const persons = await response.json();

        dispatch({ type: receivePersonsType, startDateIndex, persons });
    },
    requestPerson: id => async (dispatch, getState) => {

        dispatch({ type: requestPersonType, id });

        const person = getState().reducerPerson.persons.filter(p => p.id == id)[0];

        dispatch({ type: receivePersonType, person });
    },
    savePerson: person => async (dispatch, getState) => {

        //getState().uploads_reducer.upload = upload;
        getState().reducerPerson.persons.find(p => p.id == person.id).id = person.id;
        //getState().uploads_reducer.forecasts[0] = upload;
        dispatch({ type: savePersonType, person });
        /*
        const url = `api/Upload/${upload.id}`;
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(upload)
        });
        */
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestPersonsType) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            isLoading: true
        };
    }

    if (action.type === receivePersonsType) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            persons: action.persons,
            isLoading: false
        };
    }

    if (action.type === requestPersonType) {
        return {
            ...state,
            id: action.id,
            isLoading: true
        };
    }
    if (action.type === receivePersonType) {
        return {
            ...state,
            upload: action.person,
            isLoading: false
        };
    }
    if (action.type === savePersonType) {
        return {
            ...state,
            person: action.person,
            isLoading: false
        };
    }

    return state;
};
