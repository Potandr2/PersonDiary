const requestLifeEventsType = 'REQUEST_LIFEEVENTS';
const receiveLifeEventsType = 'RECEIVE_LIFEEVENTS';
const requestLifeEventType = 'REQUEST_LIFEEVENT';
const receiveLifeEventType = 'RECEIVE_LIFEEVENT';
const saveLifeEventType = 'SAVE_LIFEEVENT';
const initialState = { lifeevents: [], lifeevent: undefined, isLoading: false };

export const actionCreators = {
    requestLifeEvents: startDateIndex => async (dispatch) => {

        dispatch({ type: requestLifeEventsType, startDateIndex });

        const url = 'api/lifeevent/';
        const response = await fetch(url);
        const forecasts = await response.json();

        dispatch({ type: receiveLifeEventsType, startDateIndex, forecasts });
    },
    requestLifeEvent: id => async (dispatch, getState) => {

        dispatch({ type: requestLifeEventType, id });

        const lifeevent = getState().reducerLifeEvent.lifeevents.filter(u => u.id == id)[0];

        dispatch({ type: receiveLifeEventType, lifeevent });
    },
    saveLifeEvent: upload => async (dispatch, getState) => {

        //getState().uploads_reducer.upload = upload;
        //getState().uploads_reducer.forecasts.find(u => u.id == upload.id).fileName = upload.fileName;
        //getState().uploads_reducer.forecasts[0] = upload;
        dispatch({ type: saveLifeEventType, upload });
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

    if (action.type === requestLifeEventsType) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            isLoading: true
        };
    }

    if (action.type === receiveLifeEventsType) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            forecasts: action.forecasts,
            isLoading: false
        };
    }

    if (action.type === requestLifeEventType) {
        return {
            ...state,
            id: action.id,
            isLoading: true
        };
    }
    if (action.type === receiveLifeEventType) {
        return {
            ...state,
            upload: action.upload,
            isLoading: false
        };
    }
    if (action.type === saveLifeEventType) {
        return {
            ...state,
            upload: action.upload,
            isLoading: false
        };
    }

    return state;
};
