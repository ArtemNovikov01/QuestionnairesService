import { configureStore } from "@reduxjs/toolkit";
import buisnessmanReducer from "./buisnessman.slice";

export default configureStore({
    reducer:{
        buisnessman: buisnessmanReducer
    }
});
