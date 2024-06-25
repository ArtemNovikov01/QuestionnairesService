import { createSlice } from "@reduxjs/toolkit";
import { Buisnessman } from "../../models/form-models/buisnessmanModel";
import { CreateRequesitesBank } from "../../models/form-models/createRequesitesBank";

const buisnessmanSlice = createSlice({
    name:'buisnessman',
    initialState:{
        buisnessman: {
             inn: '',
             fullName: '',
             shortName: '',
             registrationNumber: '',
             registrationDate: undefined,
             SkanInn: undefined,
             SkanOgrnip: undefined,
             SkanResponseEgrip: undefined,
             SkanContractRent: undefined,
             AvailabilityContract: false,
             requesitesBanks: {
                bin: '',
                nameBankBranch: '',
                correspondentAccount: '',
            }
        }
    },
    reducers:{
    getBuisnessmanInfo(state,action){
        console.log(state.buisnessman);
         state.buisnessman =
         action.payload
         console.log(state.buisnessman);
    },
    setBuisnessmanInfo(state, action) {
        console.log(state.buisnessman);
        state.buisnessman = {
            ...state.buisnessman,
            inn: action.payload.inn,
            fullName: action.payload.fullName,
        };
        console.log(state.buisnessman);
    }
    }
});

export const {getBuisnessmanInfo, setBuisnessmanInfo} = buisnessmanSlice.actions;

export default buisnessmanSlice.reducer;