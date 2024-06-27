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
        addRequesitesInfo(state, action) {
            if(state.buisnessman.requesitesBanks.length === 1 && state.buisnessman.requesitesBanks[0].bin === ''){
                console.log(state.buisnessman);
                state.buisnessman = {
                    ...state.buisnessman,
                    requesitesBanks:[action.payload]
                }
                console.log(state.buisnessman);
            }
            else{
                state.buisnessman = {
                    ...state.buisnessman,
                    requesitesBanks:[...state.buisnessman.requesitesBanks, action.payload]
                }
            }
        },
//ToDo Доделать метод записи
        setRequesitesInfo(state, action) {
            console.log(state.buisnessman);
            
            state.buisnessman = {
                ...state.buisnessman,
                requesitesBanks[action.payload.index] ={
                    bin: action.payload.bin,
                    nameBankBranch: action.payload.nameBankBranch,
                    correspondentAccount: action.payload.correspondentAccount,
                    paymentAccount: action.payload.paymentAccount

                }
            }
            console.log(state.buisnessman);
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
        }
    }
});

export const {setRequesitesInfo,addRequesitesInfo, setBuisnessmanInfo} = buisnessmanSlice.actions;

export default buisnessmanSlice.reducer;