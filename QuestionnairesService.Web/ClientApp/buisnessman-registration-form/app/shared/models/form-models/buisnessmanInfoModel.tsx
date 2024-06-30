import { BuisnessmanType } from "../enums/BuisnessmanType";
import { CreateRequesitesBank } from "./createRequesitesBank";


export class BuisnessmanInfo{
    public buisnessmanType!: BuisnessmanType;
    public inn!: string;
    public fullName?: string;
    public shortName?: string;
    public registrationNumber!: string;
    public registrationDate?: string;
    public availabilityContract!: boolean
    public banks!:CreateRequesitesBank[]
}