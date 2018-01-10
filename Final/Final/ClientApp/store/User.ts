import { Action, Reducer } from 'redux';

export interface UserState {
    UserID: string;
    WorkSpace: string;
}

interface SetIDAction {
    type: 'SET_ID';
    ID: string;
    ws: string
}
interface RemoveIDAction { type: 'REMOVE_ID' }

type KnowAction = SetIDAction | RemoveIDAction;

export const actionCreators = {
    SetID: (id: string, space: string) => <SetIDAction>{ type: 'SET_ID', ID: id, ws: space },
    RemoveID: () => <RemoveIDAction>{ type: 'REMOVE_ID' }
}

export const reducer: Reducer<UserState> = (state: UserState, action: KnowAction) => {
    switch (action.type) {
        case 'SET_ID':
            return {
                UserID: action.ID,
                WorkSpace: action.ws
            }
        case 'REMOVE_ID':
            return {
                UserID: '',
                WorkSpace: ''
            }
        default:
            const exhaustiveCheck: never = action;
    }

    return state || { UserID: '', WorkSpace: '' };
}