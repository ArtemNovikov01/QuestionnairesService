import { BuisnessmanInfo } from "./buisnessmanInfoModel";
import { CreateRequesitesBank } from "./createRequesitesBank";


export class Buisnessman{
    public buisnessmanInfo!:BuisnessmanInfo;
    public SkanInn?: Blob;
    public SkanRegistrationNumber?: Blob;
    public SkanExtractFromTax?: Blob;
    public SkanContractRent?: Blob;
}