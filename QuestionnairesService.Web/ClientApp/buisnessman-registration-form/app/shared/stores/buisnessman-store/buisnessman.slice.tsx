import { createSlice } from "@reduxjs/toolkit";

const buisnessmanSlice = createSlice({
    name:'buisnessman',
    initialState:{
        buisnessman: {
            //  inn: '',
            //  fullName: '',
            //  shortName: '',
            //  registrationNumber: '',
            //  registrationDate: undefined,
            //  AvailabilityContract: false,
             requesitesBanks: [{
                bankCode: '',
                branchOfficeName: '',
                paymentAccount:'',
                correspondentAccount: ''
             }]
        },
    },
    reducers:{
        addRequesitesInfo(state, action) {
            if(state.buisnessman.requesitesBanks.length === 1 && state.buisnessman.requesitesBanks[0].bankCode === ''){
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
        },

        setRequesitesInfo(state, action) {
            const updatedRequisites = [...state.buisnessman.requesitesBanks];
            updatedRequisites[action.payload.index] = {
              bankCode: action.payload.bin,
              branchOfficeName: action.payload.nameBankBranch,
              correspondentAccount: action.payload.correspondentAccount,
              paymentAccount: action.payload.paymentAccount
            };
        
            state.buisnessman = {
              ...state.buisnessman,
              requesitesBanks: updatedRequisites
            };
          },

        // setBuisnessmanInfo(state, action) {
        //     state.buisnessman = {
        //         ...state.buisnessman,
        //         inn: action.payload.inn,
        //         fullName: action.payload.fullName,
        //         shortName: action.payload.shortName,
        //         registrationNumber: action.payload.registrationNumber,
        //         registrationDate: action.payload.registrationDate,
        //         AvailabilityContract: action.payload.AvailabilityContract,
        //     };
        // },

        deleteRequesites(state,action){
            let updatedRequisites;
            if(action.payload != 0){
                updatedRequisites = state.buisnessman.requesitesBanks.slice(0, action.payload)
            }
            else{
                updatedRequisites = state.buisnessman.requesitesBanks
            }
            state.buisnessman = {
                ...state.buisnessman,
                requesitesBanks:updatedRequisites
            }
        }
    }
});

export const {setRequesitesInfo,addRequesitesInfo,deleteRequesites} = buisnessmanSlice.actions;

export default buisnessmanSlice.reducer;