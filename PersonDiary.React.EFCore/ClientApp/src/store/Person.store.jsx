const requestPersonsType = 'REQUEST_PERSONS';
const receivePersonsType = 'RECEIVE_PERSONS';
const requestPersonType = 'REQUEST_PERSON';
const receivePersonType = 'RECEIVE_PERSON';
const savePersonType = 'SAVE_PERSON';
const deletePersonType = 'DELETE_PERSON';
const initialState = { persons: [], person: undefined, isLoading: false };

export const actionCreators = {
    requestPersons: startDateIndex => async (dispatch) => {

        dispatch({ type: requestPersonsType, startDateIndex });
        const url = `api/person/?json=${JSON.stringify({PageNo:0,PageSize:10})}`;
        const response = await fetch(url);
        const resp_person = await response.json();
        const persons = resp_person.persons;

        dispatch({ type: receivePersonsType, startDateIndex, persons });
    },
    requestPerson: id => async (dispatch, getState) => {

        dispatch({ type: requestPersonType, id });
        const url = `api/person/${id}`;
        const response = await fetch(url);
        const resp_person = await response.json();
        const person = resp_person.person;

        dispatch({ type: receivePersonType, person });
    },
    savePerson: person => async (dispatch, getState) => {
        const url = `api/Person/${person.id}`;
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({person})
        });
        
        dispatch({ type: savePersonType});
    },
    deletePerson: person => async (dispatch, getState) => {
        const url = `api/Person/${person.id}`;
        const response = await fetch(url, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
        dispatch({ type: deletePersonType });
        //dispatch(push("/persons"));
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
            person: action.person,
            isLoading: false
        };
    }
    if (action.type === savePersonType) {
        return {
            ...state,
            isLoading: false
        };
    }
    if (action.type === deletePersonType) {
        return {
            ...state,
            isLoading: false
        };
    }
    
    return state;
};
