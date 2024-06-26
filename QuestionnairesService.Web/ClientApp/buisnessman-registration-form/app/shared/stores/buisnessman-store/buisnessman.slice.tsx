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
             requesitesBanks: [{
                bin: '',
                nameBankBranch: '',
                correspondentAccount: '',
                paymentAccount:''
             }]
        },
    },
    reducers:{
        setRequesitesInfo(state, action) {
            if(state.buisnessman.requesitesBanks.length === 1 && state.buisnessman.requesitesBanks[0].bin === ''){
                state.buisnessman = {
                    ...state.buisnessman,
                    requesitesBanks:[action.payload]
                }
            }
            else{
                state.buisnessman = {
                    ...state.buisnessman,
                    requesitesBanks:[...state.buisnessman.requesitesBanks, action.payload]
                }
            }
            console.log(state.buisnessman)
        },

        setBuisnessmanInfo(state, action) {
            state.buisnessman = {
                ...state.buisnessman,
                inn: action.payload.inn,
                fullName: action.payload.fullName,
                shortName: action.payload.shortName,
                registrationNumber: action.payload.registrationNumber,
                registrationDate: action.payload.registrationDate,
                SkanInn: action.payload.SkanInn,
                SkanOgrnip: action.payload.SkanOgrnip,
                SkanResponseEgrip: action.payload.SkanResponseEgrip,
                SkanContractRent: action.payload.SkanContractRent,
                AvailabilityContract: action.payload.AvailabilityContract,
            };
            console.log(state.buisnessman);
        }
    }
});

export const {setRequesitesInfo, setBuisnessmanInfo} = buisnessmanSlice.actions;

export default buisnessmanSlice.reducer;