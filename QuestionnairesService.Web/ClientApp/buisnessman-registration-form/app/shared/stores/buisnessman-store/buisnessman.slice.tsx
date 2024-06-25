import { createSlice } from "@reduxjs/toolkit";
import { Buisnessman } from "../../models/form-models/buisnessmanModel";

const buisnessmanSlice = createSlice({
    name:'buisnessman',
    initialState:{
        buisnessman: Buisnessman
    },
    reducers:{
    getBuisnessman(state,action){
        console.log(state.buisnessman);
        //console.log(action.payload);
         state.buisnessman =
         action.payload
         console.log(state.buisnessman);
    },
    setBuisnessman(state,action){
    }
    }
});

export const {getBuisnessman, setBuisnessman} = buisnessmanSlice.actions;

export default buisnessmanSlice.reducer;