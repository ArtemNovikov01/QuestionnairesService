import { BuisnessmanType } from "@/app/shared/models/enums/BuisnessmanType";
import IndividualEntrepreneur from "../individual-entrepreneur-page-component/individual-entrepreneur-page-component";
import React from "react";
import LimitedLiabilityCompany from "../limitedLiability-company-page-component/limitedLiability-company-page-component";

export class MainEvents {
  selectType(type: BuisnessmanType, setSelectedComponent: React.Dispatch<React.SetStateAction<React.ReactNode>>) {
    if(type == BuisnessmanType.IndividualEntrepreneur)
      setSelectedComponent(<IndividualEntrepreneur/>)
    if(type == BuisnessmanType.LimitedLiabilityCompany){
      setSelectedComponent(<LimitedLiabilityCompany/>)
    }
  }
}