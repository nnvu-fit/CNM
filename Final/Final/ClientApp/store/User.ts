import { Action, Reducer } from 'redux';

export interface UserState {
    UserID: string;
}

interface SetIDAction {
    type: 'SET_ID';
    ID: string
}
interface RemoveIDAction { type: 'REMOVE_ID' }

type KnowAction = SetIDAction | RemoveIDAction;

export const actionCreators = {
    SetID: (id: string) => <SetIDAction>{ type: 'SET_ID', ID: id },
    RemoveID: () => <RemoveIDAction>{ type: 'REMOVE_ID' }
}

export const reducer: Reducer<UserState> = (state: UserState, action: KnowAction) => {
    switch (action.type) {
        case 'SET_ID':
            return {
                UserID: action.ID
            }
        case 'REMOVE_ID':
            return {
                UserID: ''
            }
        default:
            const exhaustiveCheck: never = action;
    }

    return state || { UserID: '' };
}